using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class Teachers
    {
        public Teachers()
        {
            TeacherCourses = new HashSet<TeacherCourses>();
            TeacherLanguages = new HashSet<TeacherLanguages>();
        }

        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<TeacherCourses> TeacherCourses { get; set; }
        public ICollection<TeacherLanguages> TeacherLanguages { get; set; }
    }
}
