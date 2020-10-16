using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class UserDetails
    {
     [Required]
     public Guid ID { get; set; }
     [Required]
     [EmailAddress]
     [Display(Name ="Email")]
     public string email { get; set; }
     [Required]
     [Display(Name ="First Name")]
     public string firstName { get; set; }
     [Required]
     [Display(Name = "Last Name")]
     public string lastName { get; set; }
     [Required]
     [Display(Name = "Position Title")]
     public string positionTitle { get; set; }
     public string photo { get; set; }
     public ICollection<Nominations> nominations { get; set; }




    }
    
}