using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Model;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser_Team5
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required] 
        public string Title { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public List<FundingPackage> FundingPackages { get; set; }

        [Required]
        public List<ImagePath> Images { get; set; }

        [Required]
        public List<VideoPath> Videos { get; set; }

        [Required]
        public List<StatusUpdate> StatusUpdates { get; set; }

        [Required]
        public decimal FundingGoal { get; set; } //>0 

        [Required]
        public decimal CurrentFund { get; set; } = 0;

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public DateTime Deadline { get; set; } //>DateTime.Now
        
        public User Users { get; set; }
    }
}
