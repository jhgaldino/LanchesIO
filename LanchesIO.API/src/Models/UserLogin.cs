﻿namespace LanchesIO.API.src.Models
{
    public class UserLogin
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
