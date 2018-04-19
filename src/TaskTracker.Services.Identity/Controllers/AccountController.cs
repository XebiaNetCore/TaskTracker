using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskTracker.Services.Identity.DbRepository;
using TaskTracker.Services.Identity.Model;

namespace TaskTracker.Services.Identity.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly RepositoryContext _dbContext;
        public AccountController(RepositoryContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet, Authorize]
        public IEnumerable<object> GetTasks()
        {
            var currentUser = HttpContext.User;
            var resultTasksList = new[] {
                                            new  { Id = "T1234",Title = "Task 1", Sprint="S211",Status="notstarted" },
                                            new { Id = "T1235", Title = "Task 2", Sprint="S212",Status="completed" },
                                            new  { Id = "T1236", Title = "Task 3", Sprint="S213",Status="wip" },
                                            new  { Id = "T1237", Title = "Task 4", Sprint="S211",Status="notstarted" }
      };

            return resultTasksList;
        }
    }
}
