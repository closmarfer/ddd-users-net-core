using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Domain.Contract
{
    public interface IUserRepository
    {
        void Create(User newUser);
        User GetByEmail(Email email);
        User GetUser(UserUuid uuid);
        void Update(User user);
        void UpdatePassword(UserUuid userUuid, HashedPassword hashedPassword);
        void Delete(User user);
    }
}
