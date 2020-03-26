using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.Domain.Entities
{
    public class StudentCourse : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
