using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<BackerFundingPackage> BackerFundingPackages { get; set; }
    }
}
