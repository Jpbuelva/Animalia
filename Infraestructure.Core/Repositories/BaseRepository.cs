using Infraestructure.Core.Context;
using Infraestructure.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructure.Core.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected ContextSql _context;
        protected  DbSet<T> _entities;
        public BaseRepository(ContextSql context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }


        public async Task Add(T entity)
        {
            var t=_entities.AddAsync(entity);
        }
        public async Task AddRange(List<T> entity)
        {
            var t = _entities.AddRangeAsync(entity);
        }
        public void Update(T entity)
        {
            _entities.Update(entity);

        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);

        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).FirstOrDefaultAsync();
        }
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return  _entities.Any(predicate);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }
    }
}
