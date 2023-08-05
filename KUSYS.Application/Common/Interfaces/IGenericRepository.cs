using KUSYS.Domain.Common;
using System.Linq.Expressions;

namespace KUSYS.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        bool Update(T model);
        Task<bool> DeleteAsync(int id);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
    }
}
