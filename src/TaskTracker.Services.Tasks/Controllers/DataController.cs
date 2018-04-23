using System;
using System.Threading.Tasks;
using TaskTracker.Common.Models;
using TaskTracker.Services.Tasks.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Services.Tasks.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly DataContext _context;
 
        public DataController(DataContext context)
        {
            _context = context;
        }
 
        public async Task<IActionResult> Get()
        {
            var tasks = await _context.tasks.ToArrayAsync();
 
            return Ok(tasks);
        }
    }
}