namespace LanchesIO.API.src.Models
{
    public class UserLoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
