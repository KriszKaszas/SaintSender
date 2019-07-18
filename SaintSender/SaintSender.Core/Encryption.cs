using System;
using System.Text;
using System.Security.Cryptography;


namespace SaintSender.Core
{
    public class Encryption
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;

        string Encrypt(string password, int iterations)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return string.Format("$SAINTSENDERHASH$V1${0}${1}", iterations, base64Hash);
        }

        string Hash(string password)
        {
            return Encrypt(password, 10000);
        }

        bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$SAINTSENDERHASH$V1$");
        }

        bool Verify(string password, string hashedPassword)
        {
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            var splittedHashString = hashedPassword.Replace("$SAINTSENDERHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    Console.WriteLine("Passwords don't match");
                    return false;
                }
            }
            Console.WriteLine("Passwords match");
            return true;
        }
    }
}
 