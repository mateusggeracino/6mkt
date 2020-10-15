using _6MKT.Identity.Domain.Constants;
using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Domain.Services.Interfaces;
using _6MKT.Identity.Domain.ValueObjects.AppSettings;
using _6MKT.Identity.Domain.ValueObjects.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _6MKT.Common.EmailProviders;
using _6MKT.Common.EmailProviders.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace _6MKT.Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IEmailProvider _emailProvider;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IAppSettings _appSettings;

        public UserService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IAppSettings appSettings, IEmailProvider emailProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings;
            _emailProvider = emailProvider;
        }

        public async Task<string> AddAsync(UserEntity user)
        {
            var password = user.PasswordHash;
            user.FirstPassword = user.PasswordHash;

            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            await _userManager.AddClaimAsync(user, new Claim(JwtCustomClaimNames.UserType, user.Type.ToString().ToLower()));

            if (!result.Succeeded)
                return null;

            await _emailProvider.SendPasswordAsync(new PasswordEmailModel
            {
                ToName = user.Name,
                ToEmail = user.Email,
                Password = password
            });
            
            return await _userManager.GetUserIdAsync(user);
        }

        public async Task<Token> LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);
            
            return !result.Succeeded ? null : GenerateJwt(email);
        }

        private Token GenerateJwt(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            var claims = _userManager.GetClaimsAsync(user).Result;

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.Now).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.Now).ToString(), ClaimValueTypes.Integer64));
            
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Jwt.Origin,
                Audience = _appSettings.Jwt.ValidatedAt,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Jwt.ExpireIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return new Token
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.Jwt.ExpireIn).TotalSeconds
            };
        }

        private static long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}