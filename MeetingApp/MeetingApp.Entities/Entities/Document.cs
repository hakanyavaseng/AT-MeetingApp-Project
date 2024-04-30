using MeetingApp.Core.Entities;

namespace MeetingApp.Entity.Entities
{
    public class Document : EntityBase
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Meeting Meeting { get; set; }
    }
}
