using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
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
            catch (InvalidCredentialException e)
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}