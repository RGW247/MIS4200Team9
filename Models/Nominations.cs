using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Nominations
    {
        [Key]
        public int nominationID { get; set; }
        [Required]
        [Display(Name = "Core Value")]
        public string coreValue { get; set; }
        public Guid ID { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        



    }
}