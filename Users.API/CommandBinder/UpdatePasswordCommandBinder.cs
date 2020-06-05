using Microsoft.AspNetCore.Mvc.ModelBinding;
using Users.API.Application.Commands.UpdatePassword;

namespace Users.API.CommandBinder
{
    public class UpdatePasswordCommandBinder
    {
        [BindRequired] public string Email { get; set; }
        [BindRequired] public string OldPassword { get; set; }
        [BindRequired] public string NewPassword { get; set; }

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