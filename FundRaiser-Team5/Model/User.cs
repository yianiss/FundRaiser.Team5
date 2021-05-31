using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FundRaiser_Team5
{
    public class User
    {
        public int UserId { get; set; } // not need to take it to Options, the EF will create it by default

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<BackerFundingPackage> BackerFundingPackage { get; set; }

        public List<Project> Projects { get; set; }

      //  public bool IsCreator();
       // public bool IsBacker();

    }
}