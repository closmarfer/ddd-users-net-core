using Microsoft.AspNetCore.Mvc;
using Users.API.Application.Exception;
using Users.API.Application.Queries.Login;
using Users.API.QueryBinder;

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
        public IActionResult Login([FromQuery] LoginQueryBinder loginQueryBinder)
        {
            try
            {
                _loginQueryHandler.Handle(
                    loginQueryBinder.GetQuery()
                );
            }
            catch (InvalidCredentialsException e)
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}