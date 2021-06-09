using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Dto.Entities
{
    public class HomeDto
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserFullName { get; set; }
        public List<ProjectDetails> Projects { get; set; }

        public HomeDto() { }

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
    }
}
