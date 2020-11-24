using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly DataContext _context;

        public DbRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get<T>() where T : class, IEntity
        {
            return _context.Set<T>().Where(x => x.Hide == false).AsQueryable();
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
        {
            return _context.Set<T>().Where(selector).Where(x => x.Hide == false).AsQueryable();
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            return _context.Set<T>().AsQueryable();
        }

        public Guid Add<T>(T newEntity) where T : class, IEntity
        {
            var entity = _context.Set<T>().Add(newEntity);
            return entity.Entity.Id;
        }

        public void AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity
        {
            _context.Set<T>().AddRange(newEntities);
        }

        public void Delete<T>(T entity) where T : class, IEntity
        {
            entity.Hide = true;
            _context.Update(entity);
        }

        public void Remove<T>(T entity) where T : class, IEntity
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update<T>(T entity) where T : class, IEntity
        {
            _context.Set<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
