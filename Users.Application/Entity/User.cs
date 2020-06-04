using System;
using Users.Domain.ValueObject;

namespace Users.Domain.Entity
{
    public class User
    {
        public UserUuid UserUuid { get; set; }
        public Email Email { get; set; }
        public HashedPassword HashedPassword { private get; set; }
        public Name Name { get; set; }
        public Surname Surname{ get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public PostalCode PostalCode { get; set; }
        public CountryCode CountryCode{ get; set; }


        private User(UserUuid userUuid, Email email, HashedPassword hashed_password)
        {
            UserUuid = userUuid;
            Email = email;
            HashedPassword = hashed_password;
        }

        public static User create(
            UserUuid uuid,
            Email email,
            HashedPassword hashedPassword,
            Name name,
            Surname surname,
            PhoneNumber phoneNumber,
            PostalCode postalCode,
            CountryCode countryCode
            )
        {
            var user = new User(
                uuid,
                email,
                hashedPassword
                )
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                PostalCode = postalCode,
                CountryCode = countryCode
            };

            return user;
        }

        public bool IsSamePassword(HashedPassword hashedPassword)
        {
            return HashedPassword.Value == hashedPassword.Value;
        }

        //public dynamic serialize()
        //{
        //   Quizá tenga que devolver un DTO plano, o serializar a mano en Json...
        //}
    }
}