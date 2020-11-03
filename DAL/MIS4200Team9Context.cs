using MIS4200Team9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MIS4200Team9.DAL
{
    public class MIS4200Team9Context : DbContext
    {
        public MIS4200Team9Context() : base ("name=DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // note: this is all one line!

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Nominations> Nominations { get; set; }

    }
}