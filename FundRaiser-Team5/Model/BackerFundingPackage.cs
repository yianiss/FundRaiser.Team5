using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5
{
    public class BackerFundingPackage
    {
        public int BackerFundingPackageId { get; set; }
        public Backer Backer { get; set; }
        public FundingPackage FundingPackage { get; set; }
        public DateTime CreateDate { get; set; }
        public int Price { get; set; }
        public BackerFundingPackageStatus BackerFundingPackageStatus { get; set; }
    }
}
