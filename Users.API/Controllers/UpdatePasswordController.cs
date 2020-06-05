using Microsoft.AspNetCore.Mvc;
using Users.API.Application.Commands.UpdatePassword;
using Users.API.Application.Exception;
using Users.API.CommandBinder;

namespace Users.API.Controllers
{
    [ApiController]
    public class UpdatePasswordController : ControllerBase
    {
        private readonly UpdatePasswordCommandHandler _updatePasswordCommandHandler;

        public UpdatePasswordController(UpdatePasswordCommandHandler updatePasswordCommandHandler)
        {
            _updatePasswordCommandHandler = updatePasswordCommandHandler;
        }

        [HttpPut]
        [Route("api/user/password")]
        public IActionResult User([FromForm] UpdatePasswordCommandBinder updatePasswordCommandBinder)
        {
            try
            {
                _updatePasswordCommandHandler.Handle(updatePasswordCommandBinder.GetCommand());
            }
            catch (UserNotCreatedException e)
            {
                return Conflict(new JsonResult(e.Message));
            }

            return Ok();
        }
    }
}