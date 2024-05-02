using MeetingApp.Entity.DTOs.Meeting;

namespace MeetingApp.Service.Services.Abstractions
{
    public interface IMeetingService
    {
        Task<IList<MeetingListDto>> GetAllMeetings();
        Task<string> CreateMeeting(AddMeetingDto addMeetingDto);
        Task<bool> UpdateMeeting(UpdateMeetingDto updateMeetingDto);
        Task<UpdateMeetingDto> GetOneMeeting(string id);
        Task<MeetingListDto> GetOneMeetingWithDetails(string id);
        Task<bool> CompleteMeeting(string id);
        Task<bool> DeleteMeeting(string id);
    }
}
