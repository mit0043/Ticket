using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository userrepository)
        {
            _UserRepository = userrepository;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            //return Ok(_Context.Users.Include(d=>d.Department).Include(r=>r.Role).ToList());

            return Ok(_UserRepository.GetAllUser());
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] User user)
        {
            user.Department = null;
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            _UserRepository.CreateUser(user);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateUser/{iUserId}")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            _UserRepository.UpdateUser(user);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var userDb = _UserRepository.GetUser(id);
            if (userDb == null) return NotFound();

            _UserRepository.DeleteUser(userDb);

            return Ok();
        }
    }
}
