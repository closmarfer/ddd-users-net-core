using System;
namespace Users.Domain.ValueObject
{
    public class Surname
    {
        public string Value { get; private set; }

        public Surname(string surname)
        {
            Value = surname;
        }
    }
}