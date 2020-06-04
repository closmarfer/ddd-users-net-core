using System;
namespace Users.Domain.ValueObject
{
    public class Name
    {
        public string Value { get; private set; }

        public Name(string name)
        {
            Value = name;
        }
    }
}