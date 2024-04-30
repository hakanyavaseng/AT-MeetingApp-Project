using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Entity.DTOs.Meeting
{
    public record MeetingListDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime StartingDate { get; init; }
        public DateTime EndingDate { get; init; }
        public ICollection<AppUser> Users { get; init; }
    }
}
