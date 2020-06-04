using System;
namespace Users.Domain.ValueObject
{
    public class HashedPassword
    {
        public string Value { get; private set; }

        public HashedPassword(string hashed_password)
        {
            Value = hashed_password;
        }
    }
}
