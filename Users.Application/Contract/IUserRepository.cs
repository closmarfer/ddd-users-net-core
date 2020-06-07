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
        void UpdatePassword(User user, HashedPassword newPassword);
        void Delete(User user);
    }
}
