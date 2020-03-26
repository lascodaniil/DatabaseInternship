using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class Languages
    {
        public Languages()
        {
            TeacherLanguages = new HashSet<TeacherLanguages>();
        }

        public int LanguageId { get; set; }
        public string Language { get; set; }

        public ICollection<TeacherLanguages> TeacherLanguages { get; set; }
    }
}
