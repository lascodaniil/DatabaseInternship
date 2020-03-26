using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class Students
    {
        public Students()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
