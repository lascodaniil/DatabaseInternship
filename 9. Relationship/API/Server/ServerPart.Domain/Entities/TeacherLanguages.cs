using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.Domain.Entities
{
    public class TeacherLanguages : BaseEntity
    {
        public int LanguageId { get; set; }
        public int TeacherId { get; set; }
        public Languages Language { get; set; }
        public Teacher Teacher { get; set; }
    }
}
