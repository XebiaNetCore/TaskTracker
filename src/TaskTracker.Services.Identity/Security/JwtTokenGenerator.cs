using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TaskTracker.Services.Identity.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtIssuerOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string CreateToken(string username, string email)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               };
            
            var token = new JwtSecurityToken(
                            _jwtOptions.Issuer,
                            _jwtOptions.Audience,
                            claims,
                            _jwtOptions.NotBefore,
                            _jwtOptions.Expiration,
                            _jwtOptions.SigningCredentials
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateToken(string username)
        {
            throw new NotImplementedException();
        }
    }
}