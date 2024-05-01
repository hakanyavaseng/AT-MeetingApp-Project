using AutoMapper;
using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Entity.DTOs.Meeting;
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
            IList<Meeting> meetings = await _repositoryManager.GetRepository<Meeting>().GetAllAsync().ToListAsync();
            return _mapper.Map<IList<MeetingListDto>>(meetings);
        }

        public async Task<bool> CreateMeeting(AddMeetingDto addMeetingDto)
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
                await _mailService.SendEmailAsync(new MailRequest()
                {
                    ToEmail = mails.ToArray(),
                    Subject = $"You have enrolled a meeting!",
                    Body = $"{meeting.Name},{meeting.Description}, {meeting.StartingDate} - {meeting.EndingDate}"
                });
            }
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
