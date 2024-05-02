using AutoMapper;
using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Entity.DTOs.User;
using MeetingApp.Entity.Entities;
using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAddDto, AppUser>().ReverseMap();
            CreateMap<Meeting, MeetingListDto>().ReverseMap();
            CreateMap<AddMeetingDto, Meeting>().ForMember(p=>p.Document, opt => opt.Ignore()).ReverseMap();
            CreateMap<UserListDto, AppUser>().ReverseMap();
            CreateMap<UpdateMeetingDto, Meeting>().ReverseMap();
        }
    }
}
