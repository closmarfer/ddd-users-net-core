using System.ComponentModel.DataAnnotations;
using Users.API.Application.Commands.DeleteUser;

namespace Users.API.CommandBinder
{
    public class DeleteUserCommandBinder
    {
        [Required]
        public string UserUuid { get; set; }

        public DeleteUserCommand GetCommand()
        {
            return new DeleteUserCommand(UserUuid);
        }
    }
}