using API_REST_GAME_PROJECT.Context;
using API_REST_GAME_PROJECT.DTO.UserDTO;
using API_REST_GAME_PROJECT.Models;
using API_REST_GAME_PROJECT.Passwords;
using API_REST_GAME_PROJECT.Services;
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
        private readonly UserService _userService;

        public UserController(AppDbContext context)
        {
            _context = context;
            _userService = new UserService(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            try
            {
                var users = await _userService.GetUsers();
                return Ok(new { success = true, message = "Users retrived successfully", users });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        //This function is used to create a new user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDTO userDto)
        {
            try
            {
                var user = await _userService.CreateUser(userDto);
                CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
                return Ok(new { success = true, message = "User created successfully", user });

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(new { success = true, message = "User retrieved successfully", user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("Name/{Name}")]
        public async Task<ActionResult<User>> GetUserByName(String Name)
        {
            try
            {
                var user = await _userService.GetUserByName(Name);
                return Ok(new { success = true, message = "User retrieved successfully", user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            try
            {
                var user = await _userService.DeleteUserById(id);
                return Ok(new { success = true, message = "User removed successfully", user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUserById(int id, [FromBody] UpdateUserDTO userDTO)
        {

            try
            {
                var updatedUser = await _userService.UpdateById(id, userDTO);
                return Ok(new { success = true, message = "User updated successfully", updatedUser });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
