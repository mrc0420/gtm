using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPrototype.Domain.Entities.Entity
{
  public  class PersonelDetails
    {
        public int UserId { get; set; }

        public string Address { get; set; }

        public string Affiliation { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
