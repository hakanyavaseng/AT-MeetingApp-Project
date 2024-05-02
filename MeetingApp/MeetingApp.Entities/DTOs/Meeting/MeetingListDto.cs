using MeetingApp.Entity.DTOs.User;

namespace MeetingApp.Entity.DTOs.Meeting
{
    public record MeetingListDto
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime StartingDate { get; init; }
        public DateTime EndingDate { get; init; }
        public List<Guid> UserIds { get; set; }
        public ICollection<UserListDto> Users { get; set; }
    }
}
