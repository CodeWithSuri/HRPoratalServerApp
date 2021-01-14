using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRPoratalServerApp.RepositoryPattren
{
   public interface IRepositroyBase<T>
    {


        IQueryable<T> GetAllData();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
