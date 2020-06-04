namespace Users.API.Application.Exception
{
    public class UserNotCreatedException: System.Exception
    {
        public UserNotCreatedException()
        {
        }

        public UserNotCreatedException(string message) : base(message)
        {
        }
    }
}