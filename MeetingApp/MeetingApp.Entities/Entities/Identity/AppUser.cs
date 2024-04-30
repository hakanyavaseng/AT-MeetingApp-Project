using Microsoft.AspNetCore.Identity;

namespace MeetingApp.Entity.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
    }
}
