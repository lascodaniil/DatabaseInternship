using System;
using System.Collections.Generic;

namespace APP.Models
{
    public partial class PackGrades
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
