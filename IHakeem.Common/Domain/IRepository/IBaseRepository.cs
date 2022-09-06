using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iHakeem.SharedKernal.Domain.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> AllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<int> Count();
        Task<T> GetSingle(object id);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        T AddOrUpdate(T entity, string propertyName = "Id");
        Task<List<T>> AddList(List<T> entity);
        T Update(T entity);
        T Update(T entity, params Expression<Func<T, object>>[] updatedProperties);
        List<T> UpdateList(List<T> entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);

    }
}
