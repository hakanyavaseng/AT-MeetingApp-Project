namespace MeetingApp.Entity.DTOs.User
{
    public record UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
