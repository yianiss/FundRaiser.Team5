using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Model;

namespace FundRaiser_Team5
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; } 
        public string Description { get; set; }
        public List<FundingPackage> FundingPackages { get; set; }
        public List<string> Photos { get; set; }
        public List<string> Videos { get; set; }
        public List<StatusUpdate> StatusUpdates { get; set; }
        public decimal FundingGoal { get; set; } //>0 
        public decimal CurrentFund { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } //>DateTime.Now
        public IUser User { get; set; }
    }
}
