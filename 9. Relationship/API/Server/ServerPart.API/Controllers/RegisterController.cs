using Microsoft.AspNetCore.Mvc;
using ServerPart.API.EFDbContext;
using ServerPart.API.Repositories;
using ServerPart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Add(/*[FromBody] Student student*/)
        {
           // GenericRepository studentRepository = new GenericRepository();
            Student student = new Student { /*Id=3,*/ FirstName = "Ceban", LastName = "Daniil", Email = "lascodaniil@gmail.com" };

           // studentRepository.Add(student);
           // studentRepository.Remove(student);
           // studentRepository.Update(student);

            //studentRepository.Add(student);
           // studentRepository.SaveAll();
            

            return Ok();
        }



    }
}
