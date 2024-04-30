using MeetingApp.Entity.DTOs.User;

namespace MeetingApp.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserAddDto userAddDto);
        Task<UserLoginResponseDto> LoginAsync(UserLoginDto userLoginDto);
    }
}
