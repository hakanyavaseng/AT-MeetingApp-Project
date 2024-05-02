namespace MeetingApp.Entity.DTOs.User
{
    public record UserListDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
