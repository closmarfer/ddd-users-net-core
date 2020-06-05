using System.ComponentModel.DataAnnotations;
using Users.API.Application.Commands.UpdateUser;

namespace Users.API.CommandBinder
{
    public class UpdateUserCommandBinder
    {
        [Required] public string Surname { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int PhoneNumber { get; set; }
        [Required] public int PostalCode { get; set; }
        [Required] public string CountryCode { get; set; }
        [Required] public string UserUuid { get; set; }

        public UpdateUserCommand GetCommand()
        {
            return new UpdateUserCommand(
                UserUuid,
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