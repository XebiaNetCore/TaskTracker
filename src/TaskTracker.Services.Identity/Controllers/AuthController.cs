using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TaskTracker.Services.Identity.Controllers
{
   [Route("api/[controller]")]
   public class AuthController : Controller
   {
       private readonly IConfiguration _config;
     public AuthController(IConfiguration config)
     {
        _config = config;
     }
     public IActionResult GetToken(string name,string pwd)
     {
         //just hard code here.  
       if (name == "wow" && pwd == "123")  
       {  
        var now = DateTime.UtcNow;  
  
        var claims = new Claim[]  
        {  
            new Claim(JwtRegisteredClaimNames.Sub, name),  
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)  
        };  
  
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));  
  
        var jwt = new JwtSecurityToken(  
            issuer: _config["Jwt:Issuer"],  
            audience: _config["Jwt:Aud"],  
            claims: claims,  
            notBefore: now,  
            expires: now.Add(TimeSpan.FromMinutes(30)),  
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)  
        );  
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);  
  
        return Ok(encodedJwt);  
      }  
      else  
      {  
        return Unauthorized();  
      }  
    }
  }
}