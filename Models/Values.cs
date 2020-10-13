using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Values
    {
        public int valueCode { get; set; }
        public string description { get; set; }
        public ICollection<Nominations> nominations { get; set; }
    }
}