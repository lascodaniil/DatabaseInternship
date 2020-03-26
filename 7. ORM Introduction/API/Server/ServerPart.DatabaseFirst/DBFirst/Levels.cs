using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class Levels
    {
        public Levels()
        {
            Courses = new HashSet<Courses>();
        }

        public int LevelId { get; set; }
        public string LevelCourse { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
