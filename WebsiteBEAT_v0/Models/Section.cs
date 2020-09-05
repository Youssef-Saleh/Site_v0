using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBEAT_v0.Models
{
    public class Section
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string Supervisor { get; set; }

        public List<Member> Members { get; set; }

        public Section()
        {
            Members = new List<Member>();
        }
    }
}