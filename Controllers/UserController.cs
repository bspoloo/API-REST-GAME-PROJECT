using API_REST_GAME_PROJECT.Context;
using API_REST_GAME_PROJECT.DTO.UserDTO;
using API_REST_GAME_PROJECT.Models;
using API_REST_GAME_PROJECT.Passwords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_GAME_PROJECT.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //This function is used to create a new user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDTO userDto)
        {
            User user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "User not found"
                });
            }

            return user;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "User not found"
                });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUserById(int id, UpdateUserDTO userDTO)
        {

            // Validar el modelo recibido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "User not found"
                });
            }

            user.Name = userDTO.Name;
            user.Email = userDTO.Email;

            if (!string.IsNullOrWhiteSpace(userDTO.Password))
            {
                // Encriptar la nueva contraseña
                user.Password = Encrypt.EncryptPassword(userDTO.Password);
            }

            user.Password = userDTO.Password;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
