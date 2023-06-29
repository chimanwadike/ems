using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Common.Interfaces.Persistence;
using EMS.Domain.Entities;

namespace EMS.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string emailAddress)
        {
            return _users.SingleOrDefault(u => u.EmailAddress == emailAddress);
        }

        public User? GetUserByPhone(string phoneNumber)
        {
            return _users.SingleOrDefault(u => u.PhoneNumber == phoneNumber);
        }
    }
}