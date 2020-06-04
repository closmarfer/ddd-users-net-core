namespace Users.API.Application.Exception
{
    public class UserNotDeletedException: System.Exception
    {
        public UserNotDeletedException()
        {
        }

        public UserNotDeletedException(string? message) : base(message)
        {
        }
    }
}