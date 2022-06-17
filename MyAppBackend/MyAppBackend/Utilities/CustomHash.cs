using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace MyAppBackend.Utilities
{
    public static class CustomHash
    {
        public static string HashString(string word)
        {
            byte[] salt = new byte[128 / 8];

            string hashedWord = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: word,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
            );

            return hashedWord;
        }

        public static string GetRandomHash()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
