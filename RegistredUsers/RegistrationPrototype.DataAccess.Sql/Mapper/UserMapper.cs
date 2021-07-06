using RegistrationPrototype.DataAccess.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static RegistrationPrototype.Infrastructure.Common.Enum.EnumTypes;

namespace RegistrationPrototype.DataAccess.Sql.Mapper
{
   public static class UserMapper
    {
        public static Models.User ToUser( this Domain.Entities.Entity.User user )
        {
            return user != null ? new Models.User
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                IsDeleted = false
            }:null;

        }

        public static Models.Login ToLogin(this Domain.Entities.Entity.User user, int userId)
        {
            return (user != null && userId > 0) ? new Models.Login
            {
                UserId = userId,
                Email = user.Email,
                Password = user.Password,
                UserType = Convert.ToInt32(UserRoles.RegisterdUser)
            }:null;
        }
    }
}
