using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Web.Modal.VMModel;
using Ticket_Web.Repository;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Controllers
{
    [Route("api/UserLogin")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IAuthenticationRepository _AuthenticationRepository;

        public UserLoginController(IAuthenticationRepository authenticationRepository)
        {
            _AuthenticationRepository = authenticationRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserVM userVM)
        {
            if (_AuthenticationRepository.Authenticate(userVM.UserName, userVM.Password) == null) return BadRequest("Wrong User");

            return Ok(_AuthenticationRepository.Authenticate(userVM.UserName, userVM.Password));
        }
    }
}
