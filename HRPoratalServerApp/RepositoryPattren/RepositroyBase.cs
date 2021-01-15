using HRPoratalServerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRPoratalServerApp.RepositoryPattren
{
    public abstract class RepositroyBase<T> : IRepositroyBase<T> where T : class
    {

       protected RepositryPattrenContext repositoryContext { get; set; }

        public RepositroyBase(RepositryPattrenContext pattrenContext)
        {
            this.repositoryContext = pattrenContext;
        }

        public  T Create(T entity)
        {
            this.repositoryContext.Set<T>().Add(entity);

            return entity;
        }


        public  void Delete(T entity)
        {
            this.repositoryContext.Set<T>().Remove(entity);
        }
        public  IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {

           return this.repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public  IQueryable<T> GetAllData()
        {
return   this.repositoryContext.Set<T>().AsNoTracking();

        }
        public  T Update(T entity)
        {
            this.repositoryContext.Set<T>().Update(entity);

            return entity;
        }

    }
}
