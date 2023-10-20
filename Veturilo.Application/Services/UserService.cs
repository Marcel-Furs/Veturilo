using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veturilo.Application.Exceptions;
using Veturilo.Infrastructure.Entities;
using Veturilo.Infrastructure.Repositories;

namespace Veturilo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> userRepository;
        private readonly IPasswordService passwordService;

        public UserService(IBaseRepository<User> userRepository, IPasswordService passwordService)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordService;
        }

        public int AuthUser(string username, string password)
        {
            var user = userRepository.Find(x => x.Username == username);
            if(user == null || !passwordService.ComparePassword(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new InvalidCredentialsException("Invalid credentials");
            }
            return user.Id;
        }

        public void RegisterUser(string username, string password)
        {
            var user = userRepository.Find(x => x.Username == username);
            if(user != null)
            {
                throw new InvalidCredentialsException($"User with name {username} already exists!");
            }

            passwordService.CreateHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            userRepository.Add(new User
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
        }
    }
}
