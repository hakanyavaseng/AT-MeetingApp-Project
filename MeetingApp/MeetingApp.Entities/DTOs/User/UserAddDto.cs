using Microsoft.AspNetCore.Http;

namespace MeetingApp.Entity.DTOs.User
{
    public record UserAddDto
    {
        public string UserName { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string Password { get; init; }
        public IFormFile Image { get; set; }
    }
}
