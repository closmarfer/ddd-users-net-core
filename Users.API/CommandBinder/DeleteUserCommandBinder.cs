using Microsoft.AspNetCore.Mvc.ModelBinding;
using Users.API.Application.Commands.DeleteUser;

namespace Users.API.CommandBinder
{
    public class DeleteUserCommandBinder
    {
        [BindRequired]
        public string UserUuid { get; set; }

        public DeleteUserCommand GetCommand()
        {
            return new DeleteUserCommand(UserUuid);
        }
    }
}