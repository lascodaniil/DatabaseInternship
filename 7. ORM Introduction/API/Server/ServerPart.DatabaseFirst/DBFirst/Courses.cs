using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class Courses
    {
        public Courses()
        {
            StudentCourses = new HashSet<StudentCourses>();
            TeacherCourses = new HashSet<TeacherCourses>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public string Language { get; set; }
        public int LevelId { get; set; }

        public Levels Level { get; set; }
        public ICollection<StudentCourses> StudentCourses { get; set; }
        public ICollection<TeacherCourses> TeacherCourses { get; set; }
    }
}
