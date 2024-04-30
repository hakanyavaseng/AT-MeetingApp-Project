using MeetingApp.Entity.DTOs.Document;
using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IDocumentService _documentService;

        public MeetingsController(IMeetingService meetingService, IDocumentService documentService)
        {
            _meetingService = meetingService;
            _documentService = documentService;
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
