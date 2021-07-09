using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FillMeApp.Shared.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Party")]
        public string PartyId { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        public virtual Party Party { get; set; }
    }
}