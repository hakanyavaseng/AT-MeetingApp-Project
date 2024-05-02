using MeetingApp.Entity.DTOs.Meeting;
using MeetingApp.Entity.Entities;
using MeetingApp.Service.Document; 
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Prensentation.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class MeetingsController : Controller
    {
        private readonly IMeetingService meetingService;
        private readonly IUserService userService;
        private readonly IDocumentService documentService;

        public MeetingsController(IMeetingService meetingService, IUserService userService, IDocumentService documentService)
        {
            this.meetingService = meetingService;
            this.userService = userService;
            this.documentService = documentService;
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
            string meetingId = await meetingService.CreateMeeting(addMeetingDto);
            Document document = await documentService.UploadAsync(addMeetingDto.Document, meetingId);
            document.MeetingId = Guid.Parse(meetingId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var meeting = await meetingService.GetOneMeeting(id);
            var users = await userService.GetAllUsers();
           
            meeting.Users = users.ToList();
            return View(meeting);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMeetingDto updateMeetingDto)
        {
            await meetingService.UpdateMeeting(updateMeetingDto);
            return RedirectToAction(nameof(Index)); 
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            var meeting = await meetingService.GetOneMeetingWithDetails(id);
            var document = await documentService.GetDocument(meeting.Id);
            return View((meeting,document));

        }

        [HttpGet]
        public async Task<IActionResult> Complete([FromRoute] string id)
        {
            await meetingService.CompleteMeeting(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await meetingService.DeleteMeeting(id);
            return RedirectToAction(nameof(Index));
    }

        [HttpGet]
        public async Task<IActionResult> DownloadDocument(Guid id)
        {
            var document = await documentService.GetDocument(id);

            if (document == null)
            {
                return NotFound();
            }

            Console.WriteLine("Document File Name: " + document.Path);

            var filePath = document.Path;

            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Error: Document file does not exist.");
                return NotFound("Document file does not exist.");
            }

            var contentType = "application/octet-stream";
            return PhysicalFile(filePath, contentType, Path.GetFileName(filePath));
        }
    }
}
