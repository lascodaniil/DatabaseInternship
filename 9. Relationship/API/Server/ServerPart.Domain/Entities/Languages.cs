using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.Domain.Entities
{
    public class Languages : BaseEntity
    {
        public string Language { get; set; }
        public ICollection<TeacherLanguages> TeacherLanguages { get; set; }
    }
}
