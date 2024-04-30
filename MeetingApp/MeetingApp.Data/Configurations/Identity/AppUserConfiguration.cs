using MeetingApp.Entity.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingApp.Data.Configurations.Identity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser admin = new()
            {
                Id = Guid.Parse("3279961C-856E-45B4-94F4-AFFDFDC1507D"),
                Email = "hakanyavaseng@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+905430000000",
                PhoneNumberConfirmed = true,
                FirstName = "Hakan",
                LastName = "Yavaş",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("37E97A2F-7AF7-45E6-AEB9-8A409F062CBA")
            };

            admin.PasswordHash = CreatePasswordHash(admin, "123456789");
            builder.HasData(admin);
        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            PasswordHasher<AppUser> passwordHasher = new();
            return passwordHasher.HashPassword(user, password);
        }

    }
}
