using MeetingApp.Core.Entities;
using System.Linq.Expressions;

namespace MeetingApp.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> predicate = null, bool trackChanges = false);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null, bool trackChanges = false);
        Task<T?> GetByIdAsync(Guid id, bool trackChanges = false);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
