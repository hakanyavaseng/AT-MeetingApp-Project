using MeetingApp.Entity.Entities;
using MeetingApp.Entity.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingApp.Data.Configurations
{
    public class AppUsersMeetingsConfiguration : IEntityTypeConfiguration<AppUserMeeting>
    {
        public void Configure(EntityTypeBuilder<AppUserMeeting> builder)
        {
            builder.HasKey(um => new
            {
                um.AppUserId,
                um.MeetingId
            });
            builder
                .HasOne(u => u.AppUser)
                .WithMany(um => um.AppUserMeetings)
                .HasForeignKey(um => um.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(m => m.Meeting)
                .WithMany(um => um.AppUserMeetings)
                .HasForeignKey(sc => sc.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);

                
        }
    }
}
