using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Nominations
    {
        [Key]
        public int nominationID { get; set; }
        [Required]
        [Display(Name = "Award")]
        [Range(1,7, ErrorMessage ="Please Select a Core Value")]
        public CoreValue award { get; set; }
        [Display(Name = "Nominator")]
        [Required]
        public Guid recognizor { get; set; }
        [Display(Name = "Nominee")]
        [Required]
        public Guid nomineeID { get; set; }
        [Display(Name = "Date of recognition")]
        public DateTime recognitionDate { get; set; }
        [ForeignKey("nomineeID")]
        public virtual UserDetails nominee { get; set; }
        [ForeignKey("recognizor")]
        public virtual UserDetails nominator { get; set; }
        public string description { get; set; }
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