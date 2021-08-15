using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.Entities;

namespace Abernathy.Demographics.Service.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntityBase
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity GetById(object id);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
                                  params Expression<Func<TEntity, object>>[] includes);
        void Update(TEntity entity);
    }
}