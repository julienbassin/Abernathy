using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Abernathy.Demographics.Service.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(object id);
        Task UpdateAsync(TEntity entity);
    }
}