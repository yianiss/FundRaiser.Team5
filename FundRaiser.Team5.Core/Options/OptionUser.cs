using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Options
{
    public class OptionUser
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int IsActive { get; set; }

        public List<FundingPackage> FundingPackages { get; set; }

        public List<Project> Projects { get; set; }

        public User GetUser()
        {
            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email, //Email = this.Email
                Password = Password
            };
            return user;
        }

        public OptionUser() { }

        public OptionUser(User user)
        {
            if (user != null)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Password = user.Password;
            }
        }
    }
}
