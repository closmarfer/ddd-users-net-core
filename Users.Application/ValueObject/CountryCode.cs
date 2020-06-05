using System;
using Users.Domain.Exception;

namespace Users.Domain.ValueObject
{
    public class CountryCode : ValueObjectAbstract
    {
        public string Value { get; }

        public CountryCode(string countryCode)
        {
            Value = countryCode;
            this.Validate();
        }

        private void Validate()
        {
            if (Value.Length != 2 || !HasOnlyLetters(Value))
            {
                throw InvalidCountryCodeException.Of(Value);
            }
        }
    }
}