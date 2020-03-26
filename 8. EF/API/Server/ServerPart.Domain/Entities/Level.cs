using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPart.Domain.Entities
{
    public class Level : BaseEntity
    {
        public string LevelCourse { get; set; }
    }
}
