using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Tests.Mother
{
    public static class UserMother
    {
        public static User BasicUser()
        {
            return User.create(
                new UserUuid("abc123"),
                new Email("test@test.com"),
                new HashedPassword("abc123"),
                new Name("Test"),
                new Surname("abc123"),
                new PhoneNumber(123456789),
                new PostalCode(12345),
                new CountryCode("es")
            );
        }
    }
}