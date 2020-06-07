using System.Diagnostics;
using System.Linq;
using Dapper;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;
using Users.Infrastructure.Repository.Abstract;

namespace Users.Infrastructure.Repository.MySQL
{
    public class UserRepository : RepositoryAbstract, IUserRepository
    {
        private readonly MySqlProvider _mySqlProvider;

        public UserRepository(MySqlProvider mySqlProvider, IEventDispatcher eventDispatcher) : base(eventDispatcher)
        {
            _mySqlProvider = mySqlProvider;
        }

        public void Create(User newUser)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            conn.Query<dynamic>(
                "insert into users.users (uuid, email, password, name, surname, phone_number, postal_code, country_code) VALUES (@Uuid, @Email, @Password, @Name, @Surname, @PhoneNumber, @PostalCode, @CountryCode);",
                new
                {
                    Uuid = newUser.UserUuid.Value,
                    Email = newUser.Email.Value,
                    Password = newUser.HashedPassword.Value,
                    Name = newUser.Name.Value,
                    Surname = newUser.Surname.Value,
                    PhoneNumber = newUser.PhoneNumber.Value,
                    PostalCode = newUser.PostalCode.Value,
                    CountryCode = newUser.CountryCode.Value,
                });

            DispatchEvents(newUser);
        }

        public User GetByEmail(Email email)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            var users = conn.Query<dynamic>("select * from users where email = @Email", new {Email = email.Value});

            Debug.WriteLine(users.ToString());

            if (!users.Any())
            {
                return null;
            }

            return mapUser(users.First());
        }

        public User GetUser(UserUuid uuid)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            var users = conn.Query<dynamic>("select * from users where `uuid` = @Uuid", new {Uuid = uuid.Value});

            if (!users.Any())
            {
                return null;
            }

            return mapUser(users.First());
        }

        public void Update(User user)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            conn.Query<dynamic>(
                "update users.users set email = @Email, name = @Name, surname = @Surname, phone_number = @PhoneNumber, postal_code = @PostalCode, country_code = @CountryCode where uuid = @Uuid;",
                new
                {
                    Uuid = user.UserUuid.Value,
                    Email = user.Email.Value,
                    Name = user.Name.Value,
                    Surname = user.Surname.Value,
                    PhoneNumber = user.PhoneNumber.Value,
                    PostalCode = user.PostalCode.Value,
                    CountryCode = user.CountryCode.Value,
                });

            DispatchEvents(user);
        }

        public void UpdatePassword(User user, HashedPassword hashedPassword)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            conn.Query<dynamic>("update users set password = @Password where `uuid` = @Uuid",
                new {Password = hashedPassword.Value, Uuid = user.UserUuid.Value});
            
            DispatchEvents(user);
        }

        public void Delete(User user)
        {
            var conn = _mySqlProvider.GetMySqlConnection();

            conn.Query<dynamic>("delete from users where `uuid` = @Uuid",
                new {Uuid = user.UserUuid.Value});
            
            DispatchEvents(user);
        }

        private User mapUser(dynamic user)
        {
            return User.Create(
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