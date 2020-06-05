using System.ComponentModel.DataAnnotations;
using Users.API.Application.Queries.Login;

namespace Users.API.QueryBinder
{
    public class LoginQueryBinder
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginQuery GetQuery()
        {
            return new LoginQuery(Email, Password);
        }
    }
}