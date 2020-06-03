using System;
namespace Users.Domain.ValueObject
{
    public class Email
    {
        public String Value { get; private set; }

        public Email(String value)
        {
            Value = value;
        }
    }
}
