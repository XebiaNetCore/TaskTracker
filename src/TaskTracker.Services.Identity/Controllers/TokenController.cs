using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TaskTracker.Services.Identity.DbRepository;
using TaskTracker.Services.Identity.Model;

namespace TaskTracker.Services.Identity.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private readonly RepositoryContext _dbContext;
        public TokenController(IConfiguration config, RepositoryContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
            if (!_dbContext.Registration.Any())
            {
                Registration r = new Registration
                {
                    Email = "ssrivastava@xebia.com",
                    Password = "admin@123",
                    CreateDate = DateTime.UtcNow,
                    Role = Registration.SystemRole.Admin
                };
                _dbContext.Registration.Add(r);
                _dbContext.SaveChangesAsync();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private string BuildToken(UserModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;
            var result = _dbContext.Registration.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
            if (result != null)
            {
                user = new UserModel { Name = "Saurabh Srivastava", Email = result.Email };
            }
            return user;
        }
        private class UserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthdate { get; set; }
        }
    }

}