using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string fullName
        { get
            { return lastName + ", " + firstName; }
                
                }
        public DateTime hireDate { get; set; }
        [ForeignKey("workerID")]

        public ICollection<Position> worker { get; set; }
        [ForeignKey("bossID")]

        public ICollection<Position> boss { get; set; }


    }
}