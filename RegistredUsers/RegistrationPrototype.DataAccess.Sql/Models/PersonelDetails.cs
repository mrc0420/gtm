using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationPrototype.DataAccess.Sql.Models
{
    public class PersonelDetails
    {
        [Key]
        public int PersonelId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Address { get; set; }

        public string Affiliation { get; set; }

        public byte[] ProfilePicture { get; set; }

        public User User { get; set; }
    }
}
