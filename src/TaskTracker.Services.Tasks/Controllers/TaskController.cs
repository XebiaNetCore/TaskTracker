using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Services.Tasks.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        [HttpGet]
       public IActionResult GetTasks()
       {
           var item = new [] {"task1","task2"};
           return Ok(item);
       }
       
       [Authorize]
       [HttpGet("{id}")]
       public IActionResult GetTaskById(int id)
       {
          return Ok("task1");
       }
    }
}