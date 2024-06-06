namespace API_REST_GAME_PROJECT.Passwords
{
    public class Encrypt
    {
        public static string EncryptPassword(string password)
        {
            if (BCryptHash.IsBCryptHash(password))
            {
                return password;
            }
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
