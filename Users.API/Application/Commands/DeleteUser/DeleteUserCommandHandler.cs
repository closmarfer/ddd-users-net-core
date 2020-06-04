using System;
using Users.API.Application.Exception;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.API.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
    {
        private readonly Domain.Service.DeleteUser _deleteUser;

        public DeleteUserCommandHandler(Domain.Service.DeleteUser deleteUser)
        {
            _deleteUser = deleteUser;
        }

        public void Handle(DeleteUserCommand command)
        {
            try
            {
                _deleteUser.Handle(new UserUuid(command.UserUuid));
            }
            catch (UserNotFoundException e)
            {
                throw new UserNotDeletedException("User not found");
            }
            catch (System.Exception e)
            {
                throw new UserNotDeletedException(e.Message);
            }
        }
    }
}