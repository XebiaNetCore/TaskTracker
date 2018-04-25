using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TaskTracker.Services.Identity.DbRepository;
using TaskTracker.Services.Identity.Model;
using TaskTracker.Services.Identity.Security;

namespace TaskTracker.Services.Identity.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private readonly RepositoryContext _dbContext;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public TokenController(IConfiguration config, RepositoryContext dbContext, IJwtTokenGenerator jwtTokenGenerator)
        {
            _config = config;
            _dbContext = dbContext;
            _jwtTokenGenerator = jwtTokenGenerator;
            // if (!_dbContext.Registration.Any())
            // {
            //     Registration r = new Registration
            //     {
            //         Email = "ssrivastava@xebia.com",
            //         Password = "admin@123",
            //         CreateDate = DateTime.UtcNow,
            //         Role = Registration.SystemRole.Admin
            //     };
            //     _dbContext.Registration.Add(r);
            //     _dbContext.SaveChangesAsync();
            // }
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
            var token = _jwtTokenGenerator.CreateToken(user.Name, user.Email);
            return token;
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