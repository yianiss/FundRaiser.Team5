using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Options
{
    class OptionBackerFundingPackage
    {
        public int OptionBackerFundingPackageId { get; set; }
        public int UserId { get; set; }
        public int FundingPackageId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Price { get; set; }
        public BackerFundingPackageStatus BackerFundingPackageStatus { get; set; }

        public OptionBackerFundingPackage() { }
        public OptionBackerFundingPackage(BackerFundingPackage backerFundingPackage)
        {
            if (backerFundingPackage != null)
            {
                OptionBackerFundingPackageId = backerFundingPackage.BackerFundingPackageId;
                UserId = backerFundingPackage.User.UserId;
                FundingPackageId = backerFundingPackage.FundingPackage.FundingPackageId;
                CreateDate = backerFundingPackage.CreateDate;
                Price = backerFundingPackage.Price;
                BackerFundingPackageStatus = backerFundingPackage.BackerFundingPackageStatus;
            }
        }

        public BackerFundingPackage GetBackerFundingPackage()
        {
            return new BackerFundingPackage
            {

                BackerFundingPackageId = OptionBackerFundingPackageId,
                // TODO Backer = BackerId,                  => Do we run SQL?
                // TODO FundingPackage = FundingPackageId,  => Do we run SQL?
                CreateDate = CreateDate,
                Price = Price,
                BackerFundingPackageStatus = BackerFundingPackageStatus
            };
        }
    }
}
