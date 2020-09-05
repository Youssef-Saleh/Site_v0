using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBEAT_v0.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Member> AppointedMembers { get; set; }
        public Member TaskAppointer { get; set; }

        public Task()
        {
            AppointedMembers = new List<Member>();
        }
    }
}