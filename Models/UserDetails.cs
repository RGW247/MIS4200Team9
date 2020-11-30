using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class UserDetails
    {
        [Required]
        public Guid ID { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string jobTitle { get; set; }
        [Display(Name = "Date Hired")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }
        public string photo { get; set; }
        [ForeignKey("nomineeID")]
        public ICollection<Nominations> nominees { get; set; }
        [ForeignKey("recognizor")]
        public ICollection<Nominations> nominators { get; set; }
        public string FullName

        {

            get

            {

                return firstName + " " + lastName;

            }
            


        }
    }
}
    
