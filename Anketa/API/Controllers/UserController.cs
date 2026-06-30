using Anketa.API;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDatabase _database;

        public UserController(UserDatabase database)
        {
            _database = database;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            IEnumerable<User> users = await _database.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User? user = await _database.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("users")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            User newUser = await _database.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPatch("{id}/password")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] string newPassword)
        {
            bool successAction = await _database.ChangePasswordAsync(id, newPassword);

            if (successAction == false)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletableUser(int id)
        {
            bool successAction = await _database.DeleteUserAsync(id);

            if (successAction == false)
                return NotFound();

            return NoContent();
        }
    }
}
