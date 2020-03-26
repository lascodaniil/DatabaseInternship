using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public abstract class BaseUniversity
    {
        [Key]
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Rector { get; set; }
        public int StudentsCapacity { get; set; }

        [Timestamp]
        public byte[] IsRowByte { get; set; }
    }
}
