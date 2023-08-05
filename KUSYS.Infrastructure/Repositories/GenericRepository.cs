using KUSYS.Application.Common.Interfaces;
using KUSYS.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KUSYS.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly KUSYSContext _context;
        public GenericRepository(KUSYSContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) { return false; }
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;

        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(method);
        }

        public bool Update(T model)
        {
            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return true;
        }
    }
}
