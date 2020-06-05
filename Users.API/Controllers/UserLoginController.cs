using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Users.API.Application.Queries.Login;

namespace Users.API.Controllers
{
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly LoginQueryHandler _loginQueryHandler;

        public UserLoginController(LoginQueryHandler loginQueryHandler)
        {
            _loginQueryHandler = loginQueryHandler;
        }

        // GET: api/Login
        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                _loginQueryHandler.Handle(
                    new LoginQuery(
                        email,
                        password
                    )
                );
            }
            catch (InvalidCredentialException e)
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}