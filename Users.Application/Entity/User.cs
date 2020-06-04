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
            string uuid,
            string email,
            string hashed_password,
            string name,
            string surname,
            int phone_number,
            int postal_code,
            string country_code
            )
        {
            var user = new User(
                new UserUuid(uuid),
                new Email(email),
                new HashedPassword(hashed_password)
                )
            {
                Name = new Name(name),
                Surname = new Surname(surname),
                PhoneNumber = new PhoneNumber(phone_number),
                PostalCode = new PostalCode(postal_code),
                CountryCode = new CountryCode(country_code)
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