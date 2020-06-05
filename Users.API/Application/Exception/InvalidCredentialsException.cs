namespace Users.API.Application.Exception
{
    public class InvalidCredentialsException: System.Exception
    {
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }
    }
}