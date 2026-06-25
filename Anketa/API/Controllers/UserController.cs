using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private List<User> _users =
        [
            new User(0, "Petya", "Petya12345"),
            new User(1, "Max222", "222MaxNeMax222"),
            new User(2, "Byk", "qwerty123456"),
        ];


        [HttpGet("all")]
        public ActionResult<List<User>> ShowAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet("id")]
        public ActionResult<User> ShowUser(int id)
        {
            User? user = _users.FirstOrDefault(user => user.Id == id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPatch("UserChange")]
        public ActionResult ChangeUser(int id, int changeId, string changeLogin, string ChangePassword)
        {
            User? user = _users.FirstOrDefault(user => user.Id == id);

            if (user == null)
                return NotFound();

            user.Change(changeId, changeLogin, ChangePassword);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteUser(int id)
        {
            User? user = _users.FirstOrDefault(user => user.Id == id);

            if (user == null)
                return NotFound();

            _users.Remove(user);

            return NoContent();
        }
    }
}
