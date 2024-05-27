namespace API_REST_GAME_PROJECT.Passwords
{
    public class Encrypt
    {
        public static string EncryptPassword(string password)
        {
            // Aquí podrías usar cualquier método de encriptación como bcrypt, por ejemplo:
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
