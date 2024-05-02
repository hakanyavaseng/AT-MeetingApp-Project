using MeetingApp.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace MeetingApp.Service.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly string _uploadFolderPath = "/documents";
        private readonly IRepositoryManager repositoryManager;

        public DocumentService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
            
        }

        public async Task<Entity.Entities.Document> GetDocument(Guid meetingId)
        {
            return await repositoryManager.GetRepository<Entity.Entities.Document>().GetAsync(p => p.MeetingId.Equals(meetingId));
        }


        public async Task<Entity.Entities.Document> UploadAsync(IFormFile file, string meetingId)
        {
            try
            {
                if (!Directory.Exists(_uploadFolderPath))
                {
                    Directory.CreateDirectory(_uploadFolderPath);
                }
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("File is not selected or empty.");
                }

                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = $"{DateTime.Now.Ticks}{fileExtension}"; // Use timestamp in file name
                var filePath = Path.Combine(_uploadFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                Entity.Entities.Document document = new()
                {
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    Path = filePath,
                    RegisteredDate = DateTime.Now,
                    Type = fileExtension,
                    MeetingId = Guid.Parse(meetingId)
                };
                await repositoryManager.GetRepository<Entity.Entities.Document>().AddAsync(document);
                await repositoryManager.SaveAsync();

                return document;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new ApplicationException($"Failed to upload file: {ex.Message}", ex);
            }
        }
    }
}
