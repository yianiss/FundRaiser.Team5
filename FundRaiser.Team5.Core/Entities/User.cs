using System.Collections.Generic;

namespace FundRaiser.Team5.Core.Entities
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