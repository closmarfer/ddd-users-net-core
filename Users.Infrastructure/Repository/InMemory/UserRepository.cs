using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.Infrastructure.Repository.InMemory
{
    public class UserRepository : IUserRepository
    {
        private ICollection<User> _usersMemory;

        public UserRepository()
        {
            _usersMemory = new Collection<User>();
        }

        public void Create(User newUser)
        {
            _usersMemory.Add(newUser);
            LogUsers();
        }

        public User GetByEmail(Email email)
        {
            foreach (var user in _usersMemory)
            {
                if (user.Email.Value.Equals(email.Value))
                {
                    return user;
                }
            }

            return null;
        }

        public User GetUser(UserUuid uuid)
        {
            foreach (var user in _usersMemory)
            {
                if (user.UserUuid.Value.Equals(uuid.Value))
                {
                    return user;
                }
            }

            return null;
            
        }

        public void Update(User user)
        {
            var existentUser = GetUser(user.UserUuid);

            if (existentUser == null)
            {
                return;
            }

            existentUser.Email = user.Email;
            existentUser.Name = user.Name;
            existentUser.Surname = user.Surname;
            existentUser.PhoneNumber = user.PhoneNumber;
            existentUser.CountryCode = user.CountryCode;
            existentUser.PostalCode = user.PostalCode;
            
            LogUsers();
        }

        public void UpdatePassword(UserUuid userUuid, HashedPassword hashedPassword)
        {
            var existentUser = GetUser(userUuid);

            if (existentUser == null)
            {
                return;
            }

            existentUser.HashedPassword = hashedPassword;
            
            LogUsers();
        }

        public void Delete(User user)
        {
            var existentUser = GetUser(user.UserUuid);

            if (existentUser == null)
            {
                return;
            }

            _usersMemory.Remove(existentUser);

            LogUsers();
        }

        private void LogUsers()
        {
            foreach (var user in _usersMemory)
            {
               Console.WriteLine("User in memory: " + user.UserUuid.Value + " with email " + user.Email.Value);
            }
        }
    }
}