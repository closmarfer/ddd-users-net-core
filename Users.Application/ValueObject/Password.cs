using System;
namespace Users.Domain.ValueObject
{
    public class Password
    {
        public string Value { get; private set; }

        public Password(string password)
        {
            Value = password;
        }
    }
}
