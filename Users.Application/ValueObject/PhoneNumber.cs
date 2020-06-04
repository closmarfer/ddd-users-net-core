using System;
namespace Users.Domain.ValueObject
{
    public class PhoneNumber
    {
        public int Value { get; private set; }

        public PhoneNumber(int phone_number)
        {
            Value = phone_number;
        }
    }
}