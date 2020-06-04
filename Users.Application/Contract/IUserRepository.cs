using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Domain.Contract
{
    public interface IUserRepository
    {
        void create(User newUser);
        User getByEmail(Email email);
    }
}
