using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.Domain.Entities
{
    public class TeacherCourse : BaseEntity
    {
       public int CourseId { get; set; }
       public int TeacherId { get; set; }
       public Course Course { get; set; }
       public Teacher Teacher { get; set; } 
    }
}
