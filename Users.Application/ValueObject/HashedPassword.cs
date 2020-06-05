namespace Users.Domain.ValueObject
{
    public class HashedPassword
    {
        public string Value { get; }

        public HashedPassword(string hashedPassword)
        {
            Value = hashedPassword;
        }
    }
}