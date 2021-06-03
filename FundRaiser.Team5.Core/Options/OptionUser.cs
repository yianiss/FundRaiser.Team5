using FundRaiser_Team5.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser_Team5.Options
{
    public class OptionUser
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<FundingPackage> FundingPackages { get; set; }

        public List<Project> Projects { get; set; }

        public OptionUser() { }

        public OptionUser(User user)
        {
            if (user != null)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Password = user.Password;
                IsActive = user.IsActive;
            }
        }
        
        public User GetUser()
        {
            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email, //Email = this.Email
                Password = Password,
                IsActive = true
            };
            return user;
        }
    }
}
