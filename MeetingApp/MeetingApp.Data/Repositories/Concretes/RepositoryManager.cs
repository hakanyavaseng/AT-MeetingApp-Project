using MeetingApp.Core.Entities;
using MeetingApp.Data.Contexts;
using MeetingApp.Data.Repositories.Abstractions;

namespace MeetingApp.Data.Repositories.Concretes
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MeetingAppDbContext _context;

        public RepositoryManager(MeetingAppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();
        public int Save() => _context.SaveChanges();
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        IRepository<T> IRepositoryManager.GetRepository<T>() => new Repository<T>(_context);
    }
}
