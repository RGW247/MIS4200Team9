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
        public int coreValueID { get; set; }
        public string coreValue { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public virtual UserDetails employees { get; set; }
        



    }
}