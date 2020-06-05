using Microsoft.AspNetCore.Mvc;
using Users.API.Application.Commands.DeleteUser;
using Users.API.Application.Exception;
using Users.API.CommandBinder;

namespace Users.API.Controllers
{
    [ApiController]
    public class DeleteUserController : ControllerBase
    {
        private readonly DeleteUserCommandHandler _deleteUserCommandHandler;

        public DeleteUserController(DeleteUserCommandHandler deleteUserCommandHandler)
        {
            _deleteUserCommandHandler = deleteUserCommandHandler;
        }

        [HttpDelete]
        [Route("api/user/{UserUuid}")]
        public IActionResult User([FromRoute] DeleteUserCommandBinder deleteUserCommandBinder)
        {
            try
            {
                _deleteUserCommandHandler.Handle(deleteUserCommandBinder.GetCommand());
            }
            catch (UserNotDeletedException e)
            {
                return Conflict(new JsonResult(e.Message));
            }

            return Ok();
        }
    }
}