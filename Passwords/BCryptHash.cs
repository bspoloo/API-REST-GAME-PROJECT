namespace API_REST_GAME_PROJECT.Passwords
{
    public class BCryptHash
    {
        public BCryptHash()
        {
            
        }
        public static bool IsBCryptHash(string password)
        {
            return password.StartsWith("$2a$") || password.StartsWith("$2b$") || password.StartsWith("$2y$");
        }
    }
}
