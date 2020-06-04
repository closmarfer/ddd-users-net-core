using System;
namespace Users.Domain.ValueObject
{
    public class UserUuid
    {
        public string Value { get; private set; }

        public UserUuid(string uuid)
        {
            Value = uuid;
        }
    }
}
