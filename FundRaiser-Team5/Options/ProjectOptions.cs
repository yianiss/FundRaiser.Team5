using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Options
{
    public class ProjectOptions
    {
        public string ProjectCode { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public int Category { get; set; } //specific categories
        public string Description { get; set; }
        public List<string> Photos { get; set; } // URL
        public List<string> Videos { get; set; }// URL
        public List<StatusUpdate> StatusUpdates { get; set; }
        public decimal FundingGoal { get; set; } //>0 
        public decimal CurrentFund { get; set; } // >0
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } //>DateTime.Now
    }
}
