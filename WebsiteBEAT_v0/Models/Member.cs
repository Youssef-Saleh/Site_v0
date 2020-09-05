using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBEAT_v0.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string College { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Position { get; set; }
        public DateTime? BirthDate { get; set; }

        public List<Section> Sections { get; set; }
        public List<Task> TasksAppointed { get; set; }
        public List<Task> TasksToAppoint { get; set; }
        public List<Event> Events { get; set; }

        public Member()
        {
            Sections = new List<Section>();
            TasksAppointed = new List<Task>();
            TasksToAppoint = new List<Task>();
            Events = new List<Event>();
        }

    }
}