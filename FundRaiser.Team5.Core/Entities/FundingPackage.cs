using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser_Team5.Entities
{
    public class FundingPackage
    {
        public int FundingPackageId { get; set; }

        [Required]
        public Project Project { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int MinPrice { get; set; }

        [Required]
        public int AvailablePackages { get; set; }

        public virtual List<UserFundingPackage> UserFundingPackages { get; set; }
    }
}
