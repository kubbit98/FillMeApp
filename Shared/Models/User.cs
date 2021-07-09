using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FillMeApp.Shared.Models
{
    public class User
    {
        [Key]
        [MaxLength(8)]
        public string Login { get; set; }
        [ForeignKey("Party")]
        public string PartyId { get; set; }
        [Required]
        [MaxLength(16)]
        public string Nick { get; set; }
        public virtual Party Party { get; set; }
    }
}