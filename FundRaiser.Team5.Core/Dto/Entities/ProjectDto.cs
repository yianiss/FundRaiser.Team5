using FundRaiser.Team5.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Dto.Entities
{
    public class ProjectDto
    {
        public int UserId { get; set; }
        public string UserFulltName { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public List<ImagePath> Images { get; set; }
        public List<VideoPath> Videos { get; set; }
        public List<StatusUpdate> StatusUpdates { get; set; }
        public decimal FundingGoal { get; set; } //>0 
        public decimal CurrentFund { get; set; } //= 0;
        public DateTime DateCreated { get; set; } //= DateTime.Now;
        public DateTime Deadline { get; set; } //>DateTime.Now
        public int CreatorId { get; set; }
        public string CreatorFulltName { get; set; }
        public List<fundingPackageDetails> FundingPackages { get; set; }

        public ProjectDto() { }

        public class fundingPackageDetails
        {
            public int FundingPackageId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int MinPrice { get; set; }
            public decimal NumberOfAvailablePackages { get; set; }
        }
    }
}
