using FundRaiser.Team5.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser.Team5.Core.Options
{
    public class OptionUserFundingPackage
    {
        public int OptionUserFundingPackageId { get; set; }

        public int UserId { get; set; }

        public int FundingPackageId { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        public bool IsActive { get; set; }

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

                IsActive = userFundingPackage.IsActive;
            }
        }

        public UserFundingPackage GetUserFundingPackage()
        {
            return new UserFundingPackage
            {
                UserFundingPackageId = OptionUserFundingPackageId,
                CreateDate = DateTime.Now,
                Price = Price,
                IsActive = true
            };
        }
    }
}
