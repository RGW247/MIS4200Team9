using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Nominations
    { 
        public string email { get; set; }
        public int valueId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string valueName { get; set; }
        public virtual Employees employees { get; set; }
        



    }
}