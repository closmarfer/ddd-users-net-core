using Microsoft.AspNetCore.Mvc.ModelBinding;
using Users.API.Application.Commands.CreateUser;

namespace Users.API.CommandBinder
{
    public class CreateUserCommandBinder
    {
        [BindRequired]
        public string Surname { get; set;}
        [BindRequired]
        public string Email { get; set;}
        [BindRequired]
        public string Password { get; set;}
        [BindRequired]
        public string Name { get; set;}
        [BindRequired]
        public int PhoneNumber { get; set;}
        [BindRequired]
        public int PostalCode { get; set;}
        [BindRequired]
        public string CountryCode { get; set;}

        public CreateUserCommand GetCommand()
        {
            return new CreateUserCommand(
                Surname,
                Email,
                Password,
                Name,
                PhoneNumber,
                PostalCode,
                CountryCode
                );
        }
    }
}