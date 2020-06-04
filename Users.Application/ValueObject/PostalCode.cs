using System;
namespace Users.Domain.ValueObject
{
    public class PostalCode
    {
        public int Value { get; private set; }

        public PostalCode(int postal_code)
        {
            Value = postal_code;
        }
    }
}