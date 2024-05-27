namespace API_REST_GAME_PROJECT.DTO.UserDTO
{
    public class CreateUserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } // Propiedad para el rol
        public int Score { get; set; }
    }
}
