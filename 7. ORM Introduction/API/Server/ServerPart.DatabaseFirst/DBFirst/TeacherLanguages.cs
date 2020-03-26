using System;
using System.Collections.Generic;

namespace ServerPart.DatabaseFirst.DBFirst
{
    public partial class TeacherLanguages
    {
        public int TeacherLanguagesId { get; set; }
        public int LanguageId { get; set; }
        public int TeacherId { get; set; }

        public Languages Language { get; set; }
        public Teachers Teacher { get; set; }
    }
}
