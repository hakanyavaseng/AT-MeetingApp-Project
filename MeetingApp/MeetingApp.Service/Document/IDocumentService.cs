using Microsoft.AspNetCore.Http;

public interface IDocumentService
{
    Task<MeetingApp.Entity.Entities.Document> UploadAsync(IFormFile file, string meetingId);
    Task<MeetingApp.Entity.Entities.Document> GetDocument(Guid meetingId);
}