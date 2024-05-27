using API_REST_GAME_PROJECT.Context;
using API_REST_GAME_PROJECT.DTO.UserDTO;
using API_REST_GAME_PROJECT.Models;
using API_REST_GAME_PROJECT.Passwords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST_GAME_PROJECT.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateUser([FromBody] CreateUserDTO userDto)
        {
            User user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Role = userDto.Role,
                Score = userDto.Score,
                Password = Encrypt.EncryptPassword(userDto.Password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found with that ID");
            }

            return user;
        }

        public async Task<User> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found with that ID");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateById(int id, [FromBody] UpdateUserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found with that ID");
            }
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Role = userDTO.Role;
            user.Score = userDTO.Score;

            if (!string.IsNullOrWhiteSpace(userDTO.Password))
            {
                // Encriptar la nueva contraseña
                user.Password = Encrypt.EncryptPassword(userDTO.Password);
            }

            await _context.SaveChangesAsync();
            return user;
        }

    }
}
