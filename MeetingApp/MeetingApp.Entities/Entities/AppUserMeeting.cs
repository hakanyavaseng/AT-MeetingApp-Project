using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Entity.Entities
{
    public class AppUserMeeting
    {
        public Guid AppUserId { get; set; }
        public Guid MeetingId { get; set; }
        public AppUser AppUser { get; set; }
        public Meeting Meeting { get; set; }
    }
}
