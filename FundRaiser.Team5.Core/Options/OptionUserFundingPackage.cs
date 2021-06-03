using FundRaiser.Team5.Core.Entities;
using System;

namespace FundRaiser.Team5.Core.Options
{
    public class OptionUserFundingPackage
    {
        public int OptionUserFundingPackageId { get; set; }
        public int UserId { get; set; }
        public int FundingPackageId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Price { get; set; }
        public UserFundingPackageStatus BackerFundingPackageStatus { get; set; }
        public UserFundingPackageStatus UserFundingPackageStatus { get; internal set; }

        public OptionUserFundingPackage() { }
        public OptionUserFundingPackage(UserFundingPackage userFundingPackage)
        {
            if (userFundingPackage != null)
            {
                OptionUserFundingPackageId = userFundingPackage.UserFundingPackageId;
                UserId = userFundingPackage.User.UserId;
                FundingPackageId = userFundingPackage.FundingPackage.FundingPackageId;
                CreateDate = userFundingPackage.CreateDate;
                Price = userFundingPackage.Price;
                BackerFundingPackageStatus = userFundingPackage.UserFundingPackageStatus;

            }
        }

        public UserFundingPackage GetUserFundingPackage()
        {
            return new UserFundingPackage
            {

                UserFundingPackageId = OptionUserFundingPackageId,
                CreateDate = DateTime.Now,
                Price = Price,
            };
        }
    }
}
