using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.API.Repositories.Interfaces
{
    public interface IRepository <T> where T : BaseEntity
    {
        T GetByID(int id);
        IQueryable<T> GetAll();
        void SaveAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
