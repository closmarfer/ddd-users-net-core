using Dapper;
using System;
using System.Linq;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;
using System.Diagnostics;

namespace Users.Infrastructure.Repository.MySQL
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlProvider _mySqlProvider;

        public UserRepository(MySqlProvider mySqlProvider)
        {
            _mySqlProvider = mySqlProvider;
        }

        public void Create(User newUser)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(Email email)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            var users = conn.Query<dynamic>("select * from users where email = @Email", new { Email = email.Value });

            Debug.WriteLine(users.ToString());

            if (!users.Any())
            {
                return null;
            }

            return mapUser(users.First());
        }

        public User GetUser(UserUuid uuid)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        private User mapUser(dynamic user)
        {
            return User.create(
                new UserUuid(user.uuid),
                new Email(user.email),
                new HashedPassword(user.password),
                new Name(user.name),
                new Surname(user.surname),
                new PhoneNumber(user.phone_number),
                new PostalCode(user.postal_code),
                new CountryCode(user.country_code)
            );
        }
    }
}
