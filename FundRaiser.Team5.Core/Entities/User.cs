using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FundRaiser_Team5.Entities
{
    public class User
    {
        public int UserId { get; set; } // not need to take it to Options, the EF will create it by default

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<UserFundingPackage> BackerFundingPackage { get; set; }

        public List<Project> Projects { get; set; }
        public bool IsActive { get; set; }

        //  public bool IsCreator();
        // public bool IsBacker();

    }
}