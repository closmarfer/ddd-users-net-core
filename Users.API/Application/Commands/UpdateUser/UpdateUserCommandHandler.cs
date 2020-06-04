using System;
using Users.API.Application.Exception;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.API.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
    {
        private readonly Domain.Service.UpdateUser _updateUser;

        public UpdateUserCommandHandler(Domain.Service.UpdateUser updateUser)
        {
            _updateUser = updateUser;
        }

        public void Handle(UpdateUserCommand command)
        {
            try
            {
                _updateUser.Handle(
                    new UserUuid(command.UserUuid),
                    new Email(command.Email),
                    new Name(command.Name),
                    new Surname(command.Surname),
                    new PhoneNumber(command.PhoneNumber),
                    new PostalCode(command.PostalCode),
                    new CountryCode(command.CountryCode)
                );
            }
            catch (UserNotFoundException e)
            {
                throw new UserNotUpdatedException("User not found");
            }
            catch (EmailAlreadyExistsException e)
            {
                throw new UserNotUpdatedException("Email already registered");
            }
            catch (System.Exception e)
            {
                throw new UserNotUpdatedException(e.Message);
            }
        }
    }
}