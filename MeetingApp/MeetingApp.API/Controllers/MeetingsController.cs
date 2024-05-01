using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.API.Controllers
{
    [Authorize(Roles ="User")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _meetingService.GetAllMeetings());
        }

   
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddMeetingDto meetingDto)
        {
            return Ok(await _meetingService.CreateMeeting(meetingDto));
        }

    }
}
