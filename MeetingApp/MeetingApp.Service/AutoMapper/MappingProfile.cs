using AutoMapper;
using MeetingApp.Entity.DTOs.User;
using MeetingApp.Entity.Entities.Identity;

namespace MeetingApp.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAddDto, AppUser>().ReverseMap();
        }
    }
}
