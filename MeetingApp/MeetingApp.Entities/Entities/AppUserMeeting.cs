using MeetingApp.Core.Entities;
using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Entity.Entities
{
    public class AppUserMeeting : EntityBase
    {
        public Guid AppUserId { get; set; }
        public Guid MeetingId { get; set; }
        public AppUser AppUser { get; set; }
        public Meeting Meeting { get; set; }
    }
}
