using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPIWithJWT.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoreAPIWithJWT.Utilities
{
    public class Utilities
    {
        private readonly IConfiguration _configuration;

        public Utilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static Dictionary<string, string> GetTokenInfo(string token)
        {
            var TokenInfo = new Dictionary<string, string>();

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            return claims.ToDictionary(claim => claim.Type, claim => claim.Value);
        }
    }
}
