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
                //await _dbContext.SaveChangesAsync();
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
                _dbContext.Set<TEntity>().Update(entity);
                //await _dbContext.SaveChangesAsync();
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