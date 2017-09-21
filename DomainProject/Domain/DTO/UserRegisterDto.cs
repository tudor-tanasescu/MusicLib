namespace MusicLibrary.Domain.DTO
{
    public class UserRegisterDto
    {
        public string Alias { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool RecievesEmailNotifications { get; set; }
    }
}