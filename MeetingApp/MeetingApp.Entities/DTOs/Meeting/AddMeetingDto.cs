using MeetingApp.Entity.Entities;
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
        public ICollection<Guid> UserIds  { get; set; }
    }
}

