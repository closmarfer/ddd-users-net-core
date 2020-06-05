namespace Users.Domain.Exception
{
    public class InvalidEmailException: ValueObjectValidationException
    {
        public InvalidEmailException(string message) : base(message)
        {
        }

        public static InvalidEmailException Of(string email)
        {
            return new InvalidEmailException("Invalid email: " + email);
        }
    }
}