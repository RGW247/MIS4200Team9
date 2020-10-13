using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Employees
    {
     public string email { get; set; }
     public string firstName { get; set; }
     public string lastName { get; set; }
     public string position { get; set; }
     public ICollection<Nominations> nominations { get; set; }




    }
    
}