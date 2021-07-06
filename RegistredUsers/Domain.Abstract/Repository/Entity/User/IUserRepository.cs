using RegistrationPrototype.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPrototype.Domain.Abstract.Repository.Entity
{
   public interface IUserRepository
    {
        bool Registration(User user);
        bool IsAuthorise(string email, string password);
        bool PersonelDetails(PersonelDetails personel);
    }
}
