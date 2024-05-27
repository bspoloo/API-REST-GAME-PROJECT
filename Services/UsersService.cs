using API_REST_GAME_PROJECT.Context;
using API_REST_GAME_PROJECT.DTO.UserDTO;
using API_REST_GAME_PROJECT.Models;
using API_REST_GAME_PROJECT.Passwords;
using Microsoft.EntityFrameworkCore;

namespace API_REST_GAME_PROJECT.Services
{
    public class UsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateUser(CreateUserDTO userDto)
        {
            User user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = Encrypt.EncryptPassword(userDto.Password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
