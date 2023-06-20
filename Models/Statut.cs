using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWS_Api1.Models
{
    [Table("StatutEffectif")]
    public class Statut
    {
        [Key]
        public int StatutId { get; set; }

        public string NameStatut { get; set; } = string.Empty;

        public string Since { get; set; } = null!;

    }
}