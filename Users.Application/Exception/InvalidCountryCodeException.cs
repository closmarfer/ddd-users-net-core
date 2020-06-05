namespace Users.Domain.Exception
{
    public class InvalidCountryCodeException : ValueObjectValidationException
    {
        public InvalidCountryCodeException(string message) : base(message)
        {
        }

        public static InvalidCountryCodeException Of(string countryCode)
        {
            return new InvalidCountryCodeException("Invalid country code " + countryCode);
        }
    }
}