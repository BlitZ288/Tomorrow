﻿namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WpfApp1.MyDbContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WpfApp1.MyDbContex";
        }

        protected override void Seed(WpfApp1.MyDbContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
