using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<TeacherLanguages> TeacherLanguages { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
