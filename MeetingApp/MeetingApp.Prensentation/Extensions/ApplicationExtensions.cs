using MeetingApp.Entity.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace MeetingApp.Prensentation.Extensions
{
    public static class ApplicationExtensions
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string userName = "hakanyavaseng";
            const string userPassword = "123456789";

            //UserManager
            UserManager<AppUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            //RoleManager
            RoleManager<AppRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

            AppUser user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                user = new AppUser()
                {
                    FirstName = "Hakan",
                    LastName = "Yavaş",
                    UserName = userName,
                    Email = "hakanyavaseng@gmail.com",
                    PhoneNumber = "1234567890"
                };

                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("User"))
                    {
                        await roleManager.CreateAsync(new AppRole()
                        {
                            Id = Guid.NewGuid(),
                            Name = "User",
                        });
                    }
                    await userManager.AddToRoleAsync(user, "User");
                }
                else
                    throw new Exception("User could not be created.");
            }
        }
    }
}
