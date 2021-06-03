using System;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser_Team5.Entities
{
    public class UserFundingPackage
    {
        public int UserFundingPackageId { get; set; }
        
        [Required]
        public User User { get; set; }
        
        [Required]
        public FundingPackage FundingPackage { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }
        
        [Required]
        public int Price { get; set; }
        public bool IsActive { get; internal set; }
    }
}
