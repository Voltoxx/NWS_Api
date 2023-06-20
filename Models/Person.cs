using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWS_Api1.Models
{
    [Table("NwsEffectif")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }  = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int Age { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Statut Statut { get; set; } = null!;

    }
}
