using System;
using System.Security.Authentication;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.API.Application.Commands.Login
{
    public class LoginCommandHandler
    {
        private readonly Domain.Service.Login _login;

        public LoginCommandHandler(Domain.Service.Login login)
        {
            _login = login;
        }

        public void Handle(LoginCommand command)
        {
            try
            {
                _login.Handle(
                    new Email(command.Email),
                    new Password(command.Password)
                );
            }
            catch (InvalidPasswordException e)
            {
                throw new InvalidCredentialException("Invalid credentials");
            }
        }
    }
}