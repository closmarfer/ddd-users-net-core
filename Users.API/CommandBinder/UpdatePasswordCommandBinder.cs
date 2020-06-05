using System.ComponentModel.DataAnnotations;
using Users.API.Application.Commands.UpdatePassword;

namespace Users.API.CommandBinder
{
    public class UpdatePasswordCommandBinder
    {
        [Required] public string Email { get; set; }
        [Required] public string OldPassword { get; set; }
        [Required] public string NewPassword { get; set; }

        public UpdatePasswordCommand GetCommand()
        {
            return new UpdatePasswordCommand(
                Email,
                OldPassword,
                NewPassword
            );
        }
    }
}