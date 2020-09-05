namespace WebsiteBEAT_v0.Migrations.SiteMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using WebsiteBEAT_v0.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebsiteBEAT_v0.Data.SiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SiteMigrations";
        }

        protected override void Seed(WebsiteBEAT_v0.Data.SiteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var Member1 = new Member();
            var Member2 = new Member();
            var Section1 = new Section();
            var Task1 = new Task();
            var Event1 = new Event();

            Member1.Fname = "Youssef";
            Member1.Mname = "Sherif";
            Member1.Lname = "Saleh";
            Member1.Phone = "01024";

            Member2.Fname = "Ahmed";
            Member2.Mname = "Mohamed";
            Member2.Lname = "Hamza";
            Member2.Phone = "01054";

            Section1.SectionName = "Engineering";

            Task1.Description = "xyzabc";
            Task1.Name = "A task for something";
            Task1.Status = "Incomplete";

            Event1.Name = "A cool event";
            Event1.Description = "Something happens";

            Section1.Members.Add(Member1);
            Section1.Members.Add(Member2);

            Task1.AppointedMembers.Add(Member1);

            context.Members.AddOrUpdate(Member1);
            context.Members.AddOrUpdate(Member2);
            context.Events.AddOrUpdate(Event1);
            context.Sections.AddOrUpdate(Section1);
            context.Tasks.AddOrUpdate(Task1);

        }
    }
}
