using MeetingApp.Entity.DTOs.Document;
using MeetingApp.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingApp.Service.Services.Abstractions
{
    public interface IDocumentService
    {
        Task<bool> AddDocumentAsync(DocumentAddDto documentAddDto);
        Task<Document> UploadFileAsync(IFormFile file);
    }
}
