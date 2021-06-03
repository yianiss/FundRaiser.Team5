using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Options
{
    public class OptionFundingPackage
    {
        public int OptionFundingPackageId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinPrice { get; set; }
        public int AvailablePackages { get; set; }
        public int IsActive { get; set; }

        public OptionFundingPackage() { }
        public OptionFundingPackage(FundingPackage fundingPackage)
        {
            if (fundingPackage != null)
            {
                OptionFundingPackageId = fundingPackage.FundingPackageId;
                ProjectId = fundingPackage.Project.ProjectId;
                Title = fundingPackage.Title;
                Description = fundingPackage.Description;
                MinPrice = fundingPackage.MinPrice;
                AvailablePackages = fundingPackage.AvailablePackages;
            }
        }
        public FundingPackage GetFundingPackage()
        {
            return new FundingPackage
            {
                FundingPackageId = OptionFundingPackageId,
                Title = Title,
                Description = Description,
                MinPrice = MinPrice,
                AvailablePackages = AvailablePackages,
            };
        }
    }
}
