using System.Collections.Generic;

namespace FundRaiser_Team5.Model
{
    public class FundingPackage
    {
        public int FundingPackageId { get; set; }
        public Project Project { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinPrice { get; set; }
        public int AvailablePackages { get; set; }
        public int IsActive { get; set; }
        public virtual List<UserFundingPackage> UserFundingPackages { get; set; }
    }
}
