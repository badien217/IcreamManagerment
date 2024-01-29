using Application.Interfaces.Token;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace infrastructure.Token
{
    public class TokenServices : ITokenServices
    {
        private readonly UserManager<User> userManager;
        private readonly TokenSetting tokenSettings;
        public Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            throw new NotImplementedException();
        }
    }
}
