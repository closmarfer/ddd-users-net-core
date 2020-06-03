using System;
namespace Users.Domain.ValueObject
{
    public class UserUuid
    {
        public String Uuid { get; private set; }

        public UserUuid(String uuid)
        {
            Uuid = uuid;
        }
    }
}
