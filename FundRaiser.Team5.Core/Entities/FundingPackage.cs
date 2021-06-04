using System.Collections.Generic;

namespace FundRaiser.Team5.Core.Entities
{
    public class FundingPackage
    {
        public int FundingPackageId { get; set; }

        public Project Project { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int MinPrice { get; set; }

        public int NumberOfAvailablePackages { get; set; }

        public bool IsActive { get; set; }

        public virtual List<UserFundingPackage> UserFundingPackages { get; set; }
    }
}
