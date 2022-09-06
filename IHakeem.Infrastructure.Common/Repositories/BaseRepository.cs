using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using iHakeem.SharedKernal.Domain.IRepository;
using iHakeem.Database.AppDbContext;

namespace iHakeem.Infrastructure.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<int> Count()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual async Task<T> GetSingle(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<List<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }


        public virtual async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }


        public virtual async Task<List<T>> AddList(List<T> entity)
        {

            await _dbContext.AddRangeAsync(entity);
            return entity;

        }

        public virtual T Update(T entity)
        {
            _dbContext.Update(entity);
            return entity;
        }
        public virtual T AddOrUpdate(T entity, string propertyName = "Id")
        {
            var alreadyExists = Convert.ToInt32(entity.GetType().GetProperty(propertyName).GetValue(entity)) > 0;
            _dbContext.Entry(entity).State = (alreadyExists ? EntityState.Modified : EntityState.Added);
            return entity;
        }

        public virtual List<T> UpdateList(List<T> entity)
        {

            _dbContext.UpdateRange(entity);
            return entity;

        }

        public virtual void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _dbContext.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _dbContext.Remove(entity);
            }
        }


        public async Task<List<T>> AllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public T Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            return entity;
        }


    }
}
