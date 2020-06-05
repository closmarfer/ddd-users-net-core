namespace Users.Domain.Exception
{
    public class EmptyValueException: ValueObjectValidationException
    {
        public EmptyValueException()
        {
        }

        public EmptyValueException(string message) : base(message)
        {
        }
    }
}