using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Entity.DTOs.User;
using MeetingApp.Service.Services.Abstractions;

namespace MeetingApp.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _manager;
        public UserService(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public Task<bool> CreateUserAsync(UserAddDto userAddDto)
        {
            
            
        }

        public Task<bool> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }
    }
}
