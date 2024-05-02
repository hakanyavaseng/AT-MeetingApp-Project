using MeetingApp.Entity.DTOs.User;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Prensentation.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class AuthController : Controller
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            await userService.LoginAsync(userLoginDto);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public IActionResult Register() 
        { 
            return View();
        }
    }
}
