using ServerPart.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerPart.Domain.Entities;
using ServerPart.API.EFDbContext;

namespace ServerPart.API.Repositories
{

    public abstract class GenericRepostiry<T> : IRepository<T> where T : BaseEntity
    {
        FLCenterDbContext fLCenterDbContext = new FLCenterDbContext(); 
     

        public void Add(T entity)
        {
            fLCenterDbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            fLCenterDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return fLCenterDbContext.Set<T>().AsQueryable();
        }

        public T GetByID(int id)
        {
           return fLCenterDbContext.Set<T>().FirstOrDefault(x=>x.Id == id);
        }

        public void SaveAll()
        {
            fLCenterDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            //T oldRecord = fLCenterDbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            //oldRecord = entity;

            fLCenterDbContext.Update(entity); // se poate de implimentat
            fLCenterDbContext.SaveChanges();
        }
    }


    public interface IStudentRepositoy
    { }

    public class StudentRepository :  GenericRepostiry<Student>, IStudentRepositoy
    {
        FLCenterDbContext fLCenterDbContext = new FLCenterDbContext();
    }



}