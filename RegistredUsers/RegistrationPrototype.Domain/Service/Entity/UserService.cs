using RegistrationPrototype.Domain.Abstract.Repository.Entity;
using RegistrationPrototype.Domain.Abstract.Service.Entity;
using RegistrationPrototype.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPrototype.Domain.Service.Entity
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsAuthorise(string email, string password)
        {
            return this.userRepository.IsAuthorise(email, password);
        }

        public bool PersonelDetails(PersonelDetails personel)
        {
            return this.userRepository.PersonelDetails(personel);
        }

        public bool Registration(User user)
        {
            return this.userRepository.Registration(user);
        }
    }
}
