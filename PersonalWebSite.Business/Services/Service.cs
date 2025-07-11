using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Core.Interfaces;
using System.Linq.Expressions;

namespace PersonalWebSite.Business.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.FindAsync(expression);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            _repository.Update(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity != null;
        }
    }
} 