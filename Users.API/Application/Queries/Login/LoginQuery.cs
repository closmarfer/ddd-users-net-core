namespace Users.API.Application.Queries.Login
{
    public class LoginQuery
    {
        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}