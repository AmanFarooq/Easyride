using DataAccessLayer.Entities;
 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{

    public class GenericRepository<TEntity> where TEntity : class
    {

        internal DatabaseContext Context;
        internal DbSet<TEntity> DbSet;
        internal UnitOfWork unitofwork;

        public GenericRepository(UnitOfWork unitofwork)
        {
            this.Context = unitofwork.context;
            this.DbSet = Context.Set<TEntity>();
            this.unitofwork = unitofwork;
        }
        

        public virtual IQueryable<TEntity> getAll()
        {

            return DbSet.AsQueryable();
        }


        public virtual TEntity AddNew(TEntity entity)
        {
            DbSet.Add(entity);
            
            return entity;
        }


        public virtual TEntity Find(int ID)
        {
            return DbSet.Find(ID);
        }

        


        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));


        }


        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual void SaveAsync()
        {
            Context.SaveChangesAsync();
        }

    }
}