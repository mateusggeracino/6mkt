using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Domain.Services.Interfaces;
using _6MKT.Identity.Domain.ValueObjects.AppSettings;
using _6MKT.Identity.Domain.ValueObjects.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace _6MKT.Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IAppSettings _appSettings;

        public UserService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IAppSettings appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings;
        }

        public async Task<UserEntity> AddAsync(UserEntity user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            return result.Succeeded ? user : null;
        }

        public async Task<Token> LoginAsync(UserEntity user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash, false, true);

            return !result.Succeeded ? null : GenerateJwt(user);
        }

        private Token GenerateJwt(UserEntity user)
        {
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