using MeetingApp.Entity.DTOs.User;
using Microsoft.AspNetCore.Http;

namespace MeetingApp.Entity.DTOs.Meeting
{
    public record UpdateMeetingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        //public IFormFile Document { get; set; }
        public List<Guid> UserIds { get; set; }
        public List<UserListDto> Users { get; set; } 
    }
}
