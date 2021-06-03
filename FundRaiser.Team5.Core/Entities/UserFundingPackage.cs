using FundRaiser_Team5.Model;
using System;

namespace FundRaiser_Team5
{
    public class UserFundingPackage
    {
        public int UserFundingPackageId { get; set; }
        public User User { get; set; }
        public FundingPackage FundingPackage { get; set; }
        public DateTime CreateDate { get; set; }
        public int Price { get; set; }

        public bool IsActive { get; internal set; }
    }
}
