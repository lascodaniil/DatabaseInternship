using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class StudentCourses
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Courses Course { get; set; }
        public Students Student { get; set; }
    }
}
