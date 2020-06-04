using System;
using Users.API.Application.Exception;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.API.Application.Commands.UpdatePassword
{
    public class UpdatePasswordCommandHandler
    {
        private readonly Domain.Service.UpdatePassword _updatePassword;

        public UpdatePasswordCommandHandler(Domain.Service.UpdatePassword updatePassword)
        {
            _updatePassword = updatePassword;
        }

        public void Handle(UpdatePasswordCommand command)
        {
            try
            {
                _updatePassword.Handle(
                    new Email(command.Email),
                    new Password(command.OldPassword),
                    new Password(command.NewPassword)
                );
            }
            catch (UserNotFoundException e)
            {
                throw new UserNotUpdatedException("User not found");
            }
            catch (InvalidPasswordException e)
            {
                throw new UserNotUpdatedException("Invalid passwords");
            }
        }
    }
}