using System.Security.Cryptography;
using Veturilo.Application.Services;

namespace Veturilo.API.Services
{
    public class HmacPasswordService : IPasswordService
    {
        public bool ComparePassword(string rawPassword, byte[] passwordHash, byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512(passwordSalt);
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(rawPassword));
            return hash.SequenceEqual(passwordHash);
        }

        public void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            passwordSalt = hmac.Key;
        }
    }
}
