using MeetingApp.Core.Entities;
using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Entity.Entities
{
    public class Meeting : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public ICollection<Document> Document { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
