using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class TeacherCourses
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public Courses Course { get; set; }
        public Teachers Teacher { get; set; }
    }
}
