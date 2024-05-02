using MeetingApp.Entity.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Prensentation.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);

            return View();
        }
    }
}
