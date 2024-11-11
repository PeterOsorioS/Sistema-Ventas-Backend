﻿using Data.Repository.Interface;
using Entities.Models;
using Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _password;
        public UserService(IUserRepository userRepository,
            IPasswordHasher<User> password)
        {
            _userRepository = userRepository;
            _password = password;
        }
        public void Authentication()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePassword()
        {
            throw new NotImplementedException();
        }
    }
}