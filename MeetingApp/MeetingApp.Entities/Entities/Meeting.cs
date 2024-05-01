using MeetingApp.Core.Entities;

namespace MeetingApp.Entity.Entities
{
    public class Meeting : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public ICollection<AppUserMeeting> AppUserMeetings { get; set; }
    }
}
