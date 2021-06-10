using System;
using System.Collections.Generic;

namespace FundRaiser_Team5.Dto.Entities
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<ProjectDetails> Projects { get; set; }
        public List<FundingPackageDetails> MyFundingPackage { get; set; }

        public UserDto() { }

        public class ProjectDetails
        {
            public int ProjectId { get; set; }
            public string ProjectTitle { get; set; }
            public string ProjectDescription { get; set; }
            public int ProjectCategory { get; set; }
            public decimal ProjectProgress { get; set; }
            public DateTime ProjectDeadline { get; set; }
            public string ProjectCreatorFullName { get; set; }
        }

        public class FundingPackageDetails 
        {
            public int ProjectId { get; set; }
            public string TitleProject { get; set; }
            public int FundingPackageId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }
    }
}