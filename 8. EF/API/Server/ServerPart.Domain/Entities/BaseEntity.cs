using System.ComponentModel.DataAnnotations;

namespace ServerPart.API.Repositories.Interfaces
{
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
    }
}