using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5
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
    }
}
