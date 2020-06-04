namespace Users.API.Application.Exception
{
    public class UserNotUpdatedException: System.Exception
    {
        public UserNotUpdatedException()
        {
        }

        public UserNotUpdatedException(string message) : base(message)
        {
        }
    }
}