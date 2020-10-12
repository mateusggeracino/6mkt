using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _6MKT.BackOffice.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeProfileAttribute : Attribute, IAuthorizationFilter, IAsyncAuthorizationFilter
    {
        private readonly string[] _userTypes;
        private readonly AsyncLocal<bool> _localAuthorized = new AsyncLocal<bool>();

        public AuthorizeProfileAttribute(params string[] userTypes)
        {
            _userTypes = userTypes;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AuthorizeRequest(context);
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            AuthorizeRequest(context);
            return Task.CompletedTask;
        }

        private void AuthorizeRequest(AuthorizationFilterContext context)
        {
            ValidateClaims(context.HttpContext.User.Claims);

            var filters = context.Filters
                .Select(f => f as AuthorizeProfileAttribute)
                .Where(f => f != null)
                .ToList();

            if (!filters.Any(f => f._localAuthorized.Value))
                context.Result = new ForbidResult();
        }

        private void ValidateClaims(IEnumerable<Claim> claims)
        {
            var profiles = claims.Where(x => x.Type == JwtCustomClaimNames.UserType);

            if (profiles.Any(x => _userTypes.Contains(x.Value)))
                _localAuthorized.Value = true;
        }
    }
}