namespace LanchesIO.API.src.Models
{
    public class User
    {
        public int Id { get; set; } // Defina a chave primária
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
