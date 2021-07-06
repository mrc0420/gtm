using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationPrototype.ViewModels
{
    public class PersonelDetailsViewModel
    {
        public int UserId { get; set; }

        public string Address { get; set; }

        public string Affiliation { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}
