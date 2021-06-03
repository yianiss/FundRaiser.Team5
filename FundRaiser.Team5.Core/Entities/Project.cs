using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser_Team5.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public List<FundingPackage> FundingPackages { get; set; }
        public List<ImagePath> Images { get; set; }
        public List<VideoPath> Videos { get; set; }
        public List<StatusUpdate> StatusUpdates { get; set; }
        public decimal FundingGoal { get; set; } //>0 
        public decimal CurrentFund { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } //>DateTime.Now
        public User Users { get; set; }
    }
}