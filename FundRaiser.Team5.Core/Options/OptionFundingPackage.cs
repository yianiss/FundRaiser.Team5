using FundRaiser.Team5.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser.Team5.Core.Options
{
    public class OptionFundingPackage
    {
        public int OptionFundingPackageId { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Minimum Price")]
        public int MinPrice { get; set; }

        [Required]
        [Display(Name = "Available Packages")]
        public int NumberOfAvailablePackages { get; set; }

        public bool IsActive { get; set; }

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
                NumberOfAvailablePackages = fundingPackage.NumberOfAvailablePackages;
                IsActive = fundingPackage.IsActive;
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
                NumberOfAvailablePackages = NumberOfAvailablePackages,
                IsActive = true
            };
        }
    }
}
