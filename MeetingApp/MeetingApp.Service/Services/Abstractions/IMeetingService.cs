using MeetingApp.Entity.DTOs.Meeting;

namespace MeetingApp.Service.Services.Abstractions
{
    public interface IMeetingService
    {
        Task<IList<MeetingListDto>> GetAllMeetings();
        Task<bool> CreateMeeting(AddMeetingDto addMeetingDto);
        Task<bool> UpdateMeeting(UpdateMeetingDto updateMeetingDto);
        Task<bool> DeleteMeeting(string id);
    }
}
