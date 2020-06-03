using System;
namespace Users.Domain.ValueObject
{
    public class Name
    {
        public String Value { get; private set; }

        public Name(string value)
        {
            Value = value;
        }
    }
}