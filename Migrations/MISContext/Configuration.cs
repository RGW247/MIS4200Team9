namespace MIS4200Team9.Migrations.MISContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MIS4200Team9.DAL.MIS4200Team9Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations\MISContext";
            ContextKey = "MIS4200Team9.DAL.MIS4200Team9Context";
        }

        protected override void Seed(MIS4200Team9.DAL.MIS4200Team9Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
