using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebsiteBEAT_v0.Models;

namespace WebsiteBEAT_v0.Data
{
    public class SiteContext:DbContext
    {
        public SiteContext() : base(nameOrConnectionString: "SiteConnectionString")
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}