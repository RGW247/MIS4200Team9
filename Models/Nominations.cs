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
        [Display(Name = "Core Value Recognized")]
        public string coreValue { get; set; }
        [Display(Name = "Recognized by")]
        public Guid recognizor { get; set; }
        [Display(Name = "Nominee")]
        public Guid recognized { get; set; }
        [Display(Name = "Data of recognition")]
        public DateTime recognizationDate { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public enum CoreValue
        {
            Stewardship = 1,
            Culture = 2,
            Excellence = 3,
            Innovation = 4,
            GreaterGood = 5,
            Balance = 6,
            IntegrityAndOpenness = 7,

        }
        



    }
}