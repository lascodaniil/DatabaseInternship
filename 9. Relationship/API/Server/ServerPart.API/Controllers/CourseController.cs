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
    public class CourseController : ControllerBase
    {
        CourseRepository courseRepository = new CourseRepository();
        public List<Course> GetAll()
        {
            return null;
        }

        [HttpGet]
        public Course Get(int id)
        {
            return courseRepository.GetByID(id);
        }

    }
}
