using MeetingApp.Core.Entities;

namespace MeetingApp.Entity.Entities
{
    public class Document : EntityBase
    {
        public string Path { get; set; }
        public string Type { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
