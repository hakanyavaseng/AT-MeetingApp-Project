using MeetingApp.Entity.DTOs.User;
using MeetingApp.Entity.Entities.Identity;
using Microsoft.AspNetCore.Http;

namespace MeetingApp.Entity.DTOs.Meeting
{
    public record AddMeetingDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public IFormFile Document { get; set; }
        public List<Guid> UserIds  { get; set; }
        public List<UserListDto> Users { get; set; } // Assume UserDto is the DTO representing a user

    }
}

