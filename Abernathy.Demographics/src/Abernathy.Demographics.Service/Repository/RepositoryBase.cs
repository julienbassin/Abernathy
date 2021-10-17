using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Data;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Abernathy.Demographics.Service.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        protected readonly DemographicsContext _dbContext;

        public Repository(DemographicsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity GetById(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter);
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, 
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
                                            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException();
            }

            return _dbContext.Set<TEntity>().Where(expression);
        }

        public void Add(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
            }
            catch (DbUpdateException)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                try
                {
                    TEntity exist = _dbContext.Set<TEntity>().Find(entity.Id);
                    _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                }
                catch (DbUpdateException)
                {
                    _dbContext.Entry(entity).State = EntityState.Detached;
                    throw;
                }
                
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}