using System;
namespace Users.Domain.ValueObject
{
    public class CountryCode
    {
        public string Value { get; private set; }

        public CountryCode(string country_code)
        {
            Value = country_code;
        }
    }
}