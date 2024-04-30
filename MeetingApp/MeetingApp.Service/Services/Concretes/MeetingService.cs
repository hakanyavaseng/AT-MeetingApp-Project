using AutoMapper;
using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Entity.Entities;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Service.Services.Concretes
{
    public class MeetingService : IMeetingService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IDocumentService documentService;
        private readonly IMapper _mapper;

        public MeetingService(IRepositoryManager repositoryManager, IMapper mapper, IDocumentService documentService)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            this.documentService = documentService;
        }

        public async Task<IList<MeetingListDto>> GetAllMeetings()
        {
            IList<Meeting> meetings = await _repositoryManager.GetRepository<Meeting>().GetAllAsync().ToListAsync();
            return _mapper.Map<IList<MeetingListDto>>(meetings);
        }

        public async Task<bool> CreateMeeting(AddMeetingDto addMeetingDto)
        {
            Meeting meeting = _mapper.Map<Meeting>(addMeetingDto);
            Document document = await documentService.UploadFileAsync(addMeetingDto.Document);
            meeting.Documents = new List<Document>();
            meeting.Documents.Add(document);

            await _repositoryManager.GetRepository<Meeting>().AddAsync(meeting);

            await documentService.AddDocumentAsync(new()
            {
                Document = document,
                MeetingId = meeting.Id,
            });

            return true;


        }

        public Task<bool> DeleteMeeting(int id)
        {
            throw new NotImplementedException();
        }

        
        public Task<bool> UpdateMeeting(UpdateMeetingDto updateMeetingDto)
        {
            throw new NotImplementedException();
        }
    }
}
