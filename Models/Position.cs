using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200Team9.Models
{
    public class Position
    {
        [Key]
        public int positionID { get; set; }

        public DateTime startDate { get; set; }

        public string positionTitle { get; set; }


        public int bossID { get; set; }

        public int workerID { get; set; }

        [ForeignKey("workerID")]

        public virtual Employee worker { get; set; }

        [ForeignKey("bossID")]
        public virtual Employee boss { get; set; }
    }

}