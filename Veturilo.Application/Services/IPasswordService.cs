using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veturilo.Application.Services
{
    public interface IPasswordService
    {
        void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool ComparePassword(string rawPassword, byte[] passwordHash, byte[] passwordSalt);
    }
}
