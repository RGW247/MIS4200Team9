using MIS4200Team9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MIS4200Team9.DAL
{
    public class MIS4200Team9Context : DbContext
    {
        public MIS4200Team9Context() : base ("name=DefaultConnection")
        {

        }

        public DbSet<UserDetails> Employees { get; set; }
        public DbSet<Nominations> Nominations { get; set; }

    }
}