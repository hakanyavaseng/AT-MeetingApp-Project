using MeetingApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingApp.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image()
                {
                    Id = Guid.Parse("37E97A2F-7AF7-45E6-AEB9-8A409F062CBA"),
                    FileName = "defaultfile",
                    FileType = ".jpg",
                    IsActive = true,
                    RegisteredDate = DateTime.Now,
                    AppUserId = Guid.Parse("3279961C-856E-45B4-94F4-AFFDFDC1507D")
                });
        }
    }
}
