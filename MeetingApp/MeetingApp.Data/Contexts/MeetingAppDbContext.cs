using MeetingApp.Entity.Entities;
using MeetingApp.Entity.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace MeetingApp.Data.Contexts
{
    public class MeetingAppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<AppUserMeeting> AppUserMeetings { get; set; }
        public MeetingAppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
