using System;
using System.Security.Authentication;
using Users.Domain.Exception;
using Users.Domain.ValueObject;

namespace Users.API.Application.Queries.Login
{
    public class LoginQueryHandler
    {
        private readonly Domain.Service.Login _login;

        public LoginQueryHandler(Domain.Service.Login login)
        {
            _login = login;
        }

        public void Handle(LoginQuery query)
        {
            try
            {
                _login.Handle(
                    new Email(query.Email),
                    new Password(query.Password)
                );
            }
            catch (InvalidPasswordException e)
            {
                throw new InvalidCredentialException("Invalid credentials");
            }
        }
    }
}