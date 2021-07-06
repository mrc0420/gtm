using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPrototype.DataAccess.Sql.Mapper
{
    public static class PersonelDetailsMapper
    {
        public static Models.PersonelDetails ToPersonelDetailsUpdate(this Domain.Entities.Entity.PersonelDetails details)
        {
            return details != null ? new Models.PersonelDetails
            { 
                Address = details.Address,
                Affiliation = details.Affiliation,
                ProfilePicture = details.ProfilePicture
            } : null;
        }

        //public static Models.PersonelDetails ToPersonelDetails(this Domain.Entities.Entity.PersonelDetails details)
        //{
        //    return details != null ? new Models.PersonelDetails
        //    {
        //        UserId = details.UserId,
        //        Affiliation = details.Affiliation,
        //        Address = details.Address,
        //        ProfilePicture = details.ProfilePicture

        //    } : null;
        //}
    }
}
