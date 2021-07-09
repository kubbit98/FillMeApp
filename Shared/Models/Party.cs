using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;



namespace FillMeApp.Shared.Models
{
    public class Party
    {
        [Key]
        [MaxLength(8)]
        public string Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
