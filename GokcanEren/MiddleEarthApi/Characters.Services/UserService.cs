﻿using Characters.Dal.Repository;
using Characters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Services
{
    public class UserService:IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Validate(string username, string password)
        {
            var user = _userRepository.ValidateUser(username, password);
            return user;
        }
    }
}

