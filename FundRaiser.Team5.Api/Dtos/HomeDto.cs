using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Api.Dtos
{
    public class HomeDto
    {
        public int UserId { get; set; }
        public string UserFulltName { get; set; }
        public List<ProjectDetails> Projects { get; set; }

        public HomeDto() { }

        public class ProjectDetails {
            public int ProjectId { get; set; }
            public string ProjectTitle { get; set; }
            public string ProjectDescription { get; set; }
            public int ProjectCategory { get; set; }
            public decimal ProjectProgress { get; set; }
            public DateTime ProjectDeadline { get; set; }
            public string ProjectCreatorFullName { get; set; }
        }
}



}
