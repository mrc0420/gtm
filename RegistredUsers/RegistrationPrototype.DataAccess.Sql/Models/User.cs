using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistrationPrototype.DataAccess.Sql.Models
{
 public    class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Lase name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsDeleted { get; set; }

        public Login Login { get; set; }

    }
}
