using Microsoft.AspNetCore.Http;
using RegistrationPrototype.Domain.Entities.Entity;
using RegistrationPrototype.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationPrototype.Controllers.Helper
{
    public static class UserControllerHelper
    {
        public static User ToUserDomain(this UserViewModel model)
        {
            return new User
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                IsDeleted = model.IsDeleted,
                Email = model.Email,
                Password = model.Password,
                UserType = model.UserType
            };
        
        }

        public static PersonelDetails ToPersonelDetailsDomain(this PersonelDetailsViewModel model)
        {
            return new Domain.Entities.Entity.PersonelDetails
            {
                UserId = model.UserId,
                Address = model.Address,
                Affiliation = model.Affiliation,
                ProfilePicture = model.ProfilePicture.ToByteType()
            };

        }


        private static byte[] ToByteType(this IFormFile image)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.OpenReadStream().CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    return imageBytes;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
