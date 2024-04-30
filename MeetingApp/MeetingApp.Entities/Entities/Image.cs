using MeetingApp.Core.Entities;
using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Entity.Entities
{
    public class Image : EntityBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set;}
    }
}
