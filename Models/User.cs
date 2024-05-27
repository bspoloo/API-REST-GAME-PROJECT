﻿namespace API_REST_GAME_PROJECT.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } // Propiedad para el rol
        public int Score { get; set; }
    }
}
