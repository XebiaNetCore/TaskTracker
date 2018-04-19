using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Api.Models
 {
   public interface IMicroserviceRepository
   {
       IEnumerable<Microservice> GetMicroservices();
       object GetMicroserviceById(int id);

       int CreateMicroservice(Microservice data);

       string DeleteMicroService(int id);
   }

   public class MicroserviceRepository:IMicroserviceRepository
   {
     private readonly AppDBContext _context;

     public MicroserviceRepository(AppDBContext context)
     {
         _context = context; 
         if(_context.Microservices.Count() == 0){
           _context.Microservices.Add(new Microservice {Name = "Identity"});
           _context.SaveChangesAsync();
        } 
     }       
     public IEnumerable<Microservice> GetMicroservices()
     {        
         var services = _context.Microservices.ToList();
         return services;
     }

     public object GetMicroserviceById(int id)
     {
        var service = _context.Microservices.SingleOrDefault(x => x.Id == id);
        return service;
     }

     public int CreateMicroservice(Microservice service)
     {
        _context.Microservices.Add(service);
        _context.SaveChangesAsync();
        return service.Id;
     }

     public string DeleteMicroService(int id)
     {
       var service = _context.Microservices.SingleOrDefault(x => x.Id == id);
       if(service == null) return "Not Found";
       _context.Microservices.Remove(service);
       _context.SaveChangesAsync();
       return "Deleted";
     }
   }
 }