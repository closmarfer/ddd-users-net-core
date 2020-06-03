using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Domain.Contract
{
    public interface IUserRepository
    {
        User getByEmail(Email email);
    }
}
