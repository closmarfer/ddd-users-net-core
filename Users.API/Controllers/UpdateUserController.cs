using Microsoft.AspNetCore.Mvc;
using Users.API.Application.Commands.UpdateUser;
using Users.API.Application.Exception;
using Users.API.CommandBinder;

namespace Users.API.Controllers
{
    [ApiController]
    public class UpdateUserController : ControllerBase
    {
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;

        public UpdateUserController(UpdateUserCommandHandler updateUserCommandHandler)
        {
            _updateUserCommandHandler = updateUserCommandHandler;
        }

        [HttpPut]
        [Route("api/user/{userUuid}")]
        public IActionResult User([FromForm] UpdateUserCommandBinder updateUserCommandBinder)
        {
            try
            {
                _updateUserCommandHandler.Handle(updateUserCommandBinder.GetCommand());
            }
            catch (UserNotCreatedException e)
            {
                return Conflict(new JsonResult(e.Message));
            }

            return Ok();
        }
    }
}