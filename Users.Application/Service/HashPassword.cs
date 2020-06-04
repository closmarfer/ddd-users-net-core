using System;
using Users.Domain.ValueObject;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Users.Domain.Service
{
    public class HashPassword
    {
        public virtual HashedPassword handle(Password password)
        {
            byte[] salt = new byte[128 / 8];

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password.Value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            //A8X0HynmsCNWHOCgKss9qGVEAY65T/sKhLcBWzWx5kw=
            return new HashedPassword(hashed);
        }
        
    }
}
