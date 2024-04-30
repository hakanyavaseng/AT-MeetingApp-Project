using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Entity.DTOs.Document;
using MeetingApp.Entity.Entities;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;

namespace MeetingApp.Service.Services.Concretes
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public DocumentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> AddDocumentAsync(DocumentAddDto documentAddDto)
        {
            List<Document> documents = new();
            documents.Add(documentAddDto.Document);
            await _repositoryManager.GetRepository<Document>().AddRangeAsync(documents);
            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<Document> UploadFileAsync(IFormFile file)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            
            return new Document() 
            { 
                FileName = uniqueFileName,
                 FileType = file.ContentType,
                  Title = $"EXAMPLE DOC {uniqueFileName}"
            };
        }
    }
}
