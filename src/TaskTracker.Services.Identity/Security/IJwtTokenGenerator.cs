using System;
using System.Threading.Tasks;
namespace TaskTracker.Services.Identity.Security
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(string username);
        string CreateToken(string username, string email);
    }
}