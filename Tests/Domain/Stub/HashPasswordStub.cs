using Users.Domain.Service;
using Users.Domain.ValueObject;

namespace Tests.Domain.Stub
{
    internal class HashPasswordStub : HashPassword
    {
        public override HashedPassword Handle(Password password)
        {
            return new HashedPassword(password.Value + "Hashed--");
        }
    }
}