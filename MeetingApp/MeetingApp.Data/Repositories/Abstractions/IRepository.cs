using MeetingApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace MeetingApp.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> predicate = null, bool trackChanges = false);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null, bool trackChanges = false);
        Task<T?> GetByIdAsync(Guid id, bool trackChanges = false);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        Task DeleteAsync(T entity);
    }
}
