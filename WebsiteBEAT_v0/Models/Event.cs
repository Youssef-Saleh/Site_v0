using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBEAT_v0.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate  { get; set; }
        public String Name { get; set; }

        public List<Member> AttendeeMembers { get; set; }

        public Event()
        {
            AttendeeMembers = new List<Member>();
        }
    }
}