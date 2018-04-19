using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Controllers
{
    ///<summary>
    /// Performs CRUD operations related to microservices
    ///</summary>
    [Route("api/[controller]")]    
    public class ValuesController : Controller
    {
        private readonly IMicroserviceRepository _provider;

        ///<summary>
        ///Constructor
        ///</summary>
        public ValuesController(IMicroserviceRepository provider)
        {
           _provider = provider;
        }

        ///<summary>
        /// Gets all the associated microservices
        ///</summary>
        /// <response code="200">If service exists</response> 
        [HttpGet]
        public IActionResult GetMicroServices()
        {
            var services = _provider.GetMicroservices();
            return Ok(services);
        }

        // GET api/values/5
        ///<summary>
        /// Gets the microservice with a particular id
        ///</summary>
        ///<param name="id"></param>
        /// <response code="200">If service exists</response>
        /// <response code="404">If the service does not exist</response>  
        [HttpGet("{id}",Name = "GetService")]
        public IActionResult GetMicroserviceById(int id)
        {
            var service = _provider.GetMicroserviceById(id);
            if(service == null) return NotFound();
            return Ok(service);
        }

        // POST api/values
        ///<summary>
        ///Creates a new Microservice
        ///</summary>
         ///<param name="data"></param>
        /// <response code="201">If service gets created</response>
        /// <response code="400">If the request is not valid</response>
        /// <returns>A newly created Microservice</returns>
        [HttpPost]        
        public IActionResult Post([FromBody]Microservice data)
        {
            if(data == null) return BadRequest("Pass some service data");
            if(data.Name == null) return BadRequest("Pass the name property");
            int id = _provider.CreateMicroservice(data);
            return CreatedAtRoute("GetService",new {Id= id },data);
        }

        // DELETE api/values/5
        ///<summary>
        ///Deletes a Microservice
        ///</summary>
         ///<param name="id"></param>
        /// <response code="204">If service gets deleted</response>
        /// <response code="404">If the service is not found</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _provider.DeleteMicroService(id);
            if(result == "Not Found"){
                return NotFound();
            }
            else{
                return NoContent();
            }
        }
    }
}
