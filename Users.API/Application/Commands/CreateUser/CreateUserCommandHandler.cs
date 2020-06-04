using System;
using Users.API.Application.Exception;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.API.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler
    {
        private readonly Domain.Service.CreateUser _createUser;

        public CreateUserCommandHandler(Domain.Service.CreateUser createUser)
        {
            _createUser = createUser;
        }

        public void Handle(CreateUserCommand command)
        {
            try
            {
                _createUser.Handle(
                    new Email(command.Email),
                    new Password(command.Password),
                    new Name(command.Name),
                    new Surname(command.Surname),
                    new PhoneNumber(command.PhoneNumber),
                    new PostalCode(command.PostalCode),
                    new CountryCode(command.CountryCode)
                );
            }
            catch (EmailAlreadyExistsException e)
            {
                throw new UserNotCreatedException("Email already registered");
            }
            catch (System.Exception e)
            {
                throw new UserNotCreatedException(e.Message);
            }
        }
    }
}