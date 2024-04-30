using MeetingApp.Core.Entities;

namespace MeetingApp.Data.Repositories.Abstractions
{
    public interface IRepositoryManager : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
