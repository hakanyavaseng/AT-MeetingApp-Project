using AutoMapper;
using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Entity.DTOs.User;
using MeetingApp.Entity.Entities;
using MeetingApp.Entity.Entities.Identity;
using MeetingApp.Service.Mail;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Service.Services.Concretes
{
    public class MeetingService : IMeetingService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public MeetingService(IRepositoryManager repositoryManager, UserManager<AppUser> userManager, IMailService mailService, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mailService = mailService;
            _mapper = mapper;
        }

        public async Task<IList<MeetingListDto>> GetAllMeetings()
        {
            IList<Meeting> meetings = await _repositoryManager.GetRepository<Meeting>()
                .GetAllAsync()
                .Where(p=> p.IsActive ==true)
                .OrderByDescending(p=>p.StartingDate)
                .ToListAsync();
            return _mapper.Map<IList<MeetingListDto>>(meetings);
        }

        public async Task<string> CreateMeeting(AddMeetingDto addMeetingDto)
        {
            List<string> mails = new();
            Meeting meeting = _mapper.Map<Meeting>(addMeetingDto);

            if (addMeetingDto.UserIds is not null)
            {
                foreach (var item in addMeetingDto.UserIds)
                {
                    //Get email addresses of attendees
                    var user = await _userManager.FindByIdAsync(item.ToString());
                    mails.Add(user.Email);
                    //Add data to AppUserMeeting
                    await _repositoryManager.GetRepository<AppUserMeeting>().AddAsync(new AppUserMeeting()
                    {
                        AppUserId = item,
                        MeetingId = meeting.Id
                    });
                }
            }

            await _repositoryManager.GetRepository<Meeting>().AddAsync(meeting);
            if (await _repositoryManager.SaveAsync() > 0)
            {
                //await _mailService.SendEmailAsync(new MailRequest()
                //{
                //    ToEmail = mails.ToArray(),
                //    Subject = $"You have enrolled a meeting!",
                //    Body = $"{meeting.Name},{meeting.Description}, {meeting.StartingDate} - {meeting.EndingDate}"
                //});
            }
            return meeting.Id.ToString();

        }

        public async Task<bool> DeleteMeeting(string id)
        {
            var meeting = await _repositoryManager.GetRepository<Meeting>().GetByIdAsync(Guid.Parse(id));
            await _repositoryManager.GetRepository<Meeting>().DeleteAsync(meeting);
            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateMeeting(UpdateMeetingDto updateMeetingDto)
        {
            Meeting? meetingToUpdate = await _repositoryManager.GetRepository<Meeting>().GetAsync(p => p.Id.Equals(updateMeetingDto.Id),false);
            
            if(meetingToUpdate is null)
                throw new ArgumentNullException(nameof(meetingToUpdate));

            _mapper.Map(updateMeetingDto, meetingToUpdate);

            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<bool> CompleteMeeting(string id)
        {
            Meeting? meeting = await _repositoryManager.GetRepository<Meeting>().GetByIdAsync(Guid.Parse(id),true);

            if(meeting is null)
                throw new ArgumentNullException(nameof(meeting));

            meeting.IsActive = false;
            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<UpdateMeetingDto> GetOneMeeting(string id)
        {
            var meeting = await _repositoryManager.GetRepository<Meeting>().GetByIdAsync(Guid.Parse(id),false);
            var listDto = _mapper.Map<UpdateMeetingDto>(meeting);

            listDto.UserIds = await _repositoryManager
            .GetRepository<AppUserMeeting>()
            .GetAllAsync(p => p.MeetingId.Equals(listDto.Id))
            .Select(p => p.AppUserId)
            .ToListAsync();

            return listDto;
        }

        public async Task<MeetingListDto> GetOneMeetingWithDetails(string id)
        {
            var meeting = await _repositoryManager.GetRepository<Meeting>().GetByIdAsync(Guid.Parse(id));
            var listDto = _mapper.Map<MeetingListDto>(meeting); 

            listDto.UserIds = await _repositoryManager
            .GetRepository<AppUserMeeting>()
            .GetAllAsync(p => p.MeetingId.Equals(listDto.Id))
            .Select(p => p.AppUserId)
            .ToListAsync();

            List<UserListDto> users = new();

            foreach (var userId in listDto.UserIds)
                users.Add(_mapper.Map<UserListDto>(await _userManager.FindByIdAsync(userId.ToString())));
            
            listDto.Users = users;

            return listDto;
        }
    }
}
