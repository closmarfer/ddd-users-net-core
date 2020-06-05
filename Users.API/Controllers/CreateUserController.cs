using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using Users.API.Application.Commands.CreateUser;
using Users.API.Application.Exception;
using Users.API.CommandBinder;

namespace Users.API.Controllers
{
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        private readonly CreateUserCommandHandler _createUserCommandHandler;

        public CreateUserController(CreateUserCommandHandler createUserCommandHandler)
        {
            _createUserCommandHandler = createUserCommandHandler;
        }

        [HttpPost]
        [Route("api/user")]
        public IActionResult User([FromForm] CreateUserCommandBinder createUserCommandBinder)
        {
            try
            {
                _createUserCommandHandler.Handle(createUserCommandBinder.GetCommand());
            }
            catch (UserNotCreatedException e)
            {
                return Conflict(new JsonResult(e.Message));
            }

            return Ok();
        }
    }
}