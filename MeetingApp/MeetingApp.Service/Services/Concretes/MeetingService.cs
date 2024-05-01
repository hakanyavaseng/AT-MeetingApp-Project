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
        private readonly IMapper _mapper;

        public MeetingService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IList<MeetingListDto>> GetAllMeetings()
        {
            IList<Meeting> meetings = await _repositoryManager.GetRepository<Meeting>().GetAllAsync().ToListAsync();
            return _mapper.Map<IList<MeetingListDto>>(meetings);
        }

        public async Task<bool> CreateMeeting(AddMeetingDto addMeetingDto)
        {
            Meeting meeting = _mapper.Map<Meeting>(addMeetingDto);
  
            await _repositoryManager.GetRepository<Meeting>().AddAsync(meeting);

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
