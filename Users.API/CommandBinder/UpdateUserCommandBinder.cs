using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Users.API.Application.Commands.UpdateUser;

namespace Users.API.CommandBinder
{
    public class UpdateUserCommandBinder
    {
        [BindRequired] public string Surname { get; set; }
        [BindRequired] public string Email { get; set; }
        [BindRequired] public string Name { get; set; }
        [BindRequired] public int PhoneNumber { get; set; }
        [BindRequired] public int PostalCode { get; set; }
        [BindRequired] public string CountryCode { get; set; }
        [BindRequired] [FromRoute] public string UserUuid { get; set; }

        public UpdateUserCommand GetCommand()
        {
            return new UpdateUserCommand(
                UserUuid,
                Surname,
                Email,
                Name,
                PhoneNumber,
                PostalCode,
                CountryCode
            );
        }
    }
}