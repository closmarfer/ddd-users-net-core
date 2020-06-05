namespace Users.Domain.Exception
{
    public class ValueObjectValidationException: System.Exception
    {
        public ValueObjectValidationException()
        {
        }

        public ValueObjectValidationException(string message) : base(message)
        {
        }
    }
}