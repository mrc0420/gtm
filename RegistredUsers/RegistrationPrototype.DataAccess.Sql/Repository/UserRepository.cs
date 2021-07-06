using RegistrationPrototype.DataAccess.Sql.Mapper;
using RegistrationPrototype.DataAccess.Sql.Models;
using RegistrationPrototype.Domain.Abstract.Repository.Entity;
using RegistrationPrototype.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationPrototype.DataAccess.Sql.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryContext userDbContext;
        public UserRepository(RepositoryContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public bool Registration(Domain.Entities.Entity.User user)
        {
            try
            {

                if (!IsUserExist(user.Email))
                {

                    var userData = user.ToUser();
                    this.userDbContext.Users.Add(userData);
                    this.userDbContext.SaveChanges();

                    var loginData = user.ToLogin(userData.UserId);
                    this.userDbContext.Login.Add(loginData);
                    var result = this.userDbContext.SaveChanges();


                    return (result > 0);
                }

                else
                {
                    throw new ArgumentException("This Email already exist");
                }
            }
            catch (Exception Ex)
            {
                throw new ArgumentException("Registration failed", Ex);
            }
        }


        public bool IsUserExist(string email)
        {
            try
            {
                return this.userDbContext.Login.Any(x => x.Email == email);
            }

            catch (Exception ex)
            {
                throw new ArgumentException("Email varification failed");
            }

        }

        public bool IsAuthorise(string email, string password)
        {
            return this.userDbContext.Login.Any(x => x.Email == email && x.Password == password && x.IsDeleted == false);
        }

        public bool PersonelDetails(Domain.Entities.Entity.PersonelDetails personel)
        {
            var result = 0;
            try
            {
                var data = this.userDbContext.PersonelDetails.First(x => x.UserId == personel.UserId);
                if (data != null)
                {
                    data = personel.ToPersonelDetailsUpdate();
                    //this.userDbContext.PersonelDetails.Update(data);
                  // result =  this.userDbContext.SaveChanges();

                }
                else
                {
                    data = personel.ToPersonelDetailsUpdate();
                    this.userDbContext.PersonelDetails.Add(data);
                  //  this.userDbContext.SaveChanges();
                    
                }
                result = this.userDbContext.SaveChanges();




            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return (result > 0);


        }
    }

}
