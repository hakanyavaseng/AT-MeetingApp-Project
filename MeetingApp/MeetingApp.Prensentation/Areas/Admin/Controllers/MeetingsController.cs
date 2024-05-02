using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Prensentation.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class MeetingsController : Controller
    {
        private readonly IMeetingService meetingService;
        private readonly IUserService userService;

        public MeetingsController(IMeetingService meetingService, IUserService userService)
        {
            this.meetingService = meetingService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var meetings = await meetingService.GetAllMeetings();
            return View(meetings);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var users = await userService.GetAllUsers();
            return View(new AddMeetingDto()
            {
                Users = users.ToList(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMeetingDto addMeetingDto)
        {
            await meetingService.CreateMeeting(addMeetingDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await meetingService.DeleteMeeting(id);
            return RedirectToAction(nameof(Index));
    }
}
}
