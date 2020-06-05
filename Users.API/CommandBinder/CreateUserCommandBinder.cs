using System.ComponentModel.DataAnnotations;
using Users.API.Application.Commands.CreateUser;

namespace Users.API.CommandBinder
{
    public class CreateUserCommandBinder
    {
        [Required]
        public string Surname { get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public string Password { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public int PhoneNumber { get; set;}
        [Required]
        public int PostalCode { get; set;}
        [Required]
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