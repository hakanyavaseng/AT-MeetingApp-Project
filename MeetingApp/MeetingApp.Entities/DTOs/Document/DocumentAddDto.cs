
namespace MeetingApp.Entity.DTOs.Document
{
    public record DocumentAddDto
    {
        public Entities.Document Document { get; init; }
        public Guid MeetingId { get; set; }

    }
}
