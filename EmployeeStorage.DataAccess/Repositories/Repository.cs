using EmployeeStorage.DataAccess.Configuration;
using EmployeeStorage.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeStorage.DataAccess.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class, new()
    {
        private readonly EmployeeStorageContext context;
        private readonly DbSet<TEntity> dbSet;
        protected Repository(EmployeeStorageContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        protected DbSet<Employee> Employees => context.Employees;

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
    }
}