using System;
using Users.Domain.ValueObject;

namespace Users.Domain.Entity
{
    public class User
    {
        public UserUuid UserUuid { get; private set; }
        public Email Email { get; private set; }
        public Name Name { get; private set; }

        public User(UserUuid userUuid, Email email, Name name)
        {
            UserUuid = userUuid;
            Email = email;
            Name = name;
        }
    }
}