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

        public User getByEmail(Email email)
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

        private User mapUser(dynamic user)
        {
            return new User(
                userUuid: new UserUuid(user.uuid),
                name: new Name(user.name),
                email: new Email(user.email)
               );
        }
    }
}
