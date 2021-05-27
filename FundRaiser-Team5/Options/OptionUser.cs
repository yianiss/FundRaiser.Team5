using FundRaiser_Team5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Options
{
    public class OptionUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<FundingPackage> FundingPackages { get; set; }
        public List<Project> Projects { get; set; }

        public User GetUser()
        {
            User user = new()
            {
                UserId = UserId,
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
                UserId = user.UserId;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Password = user.Password;
            }
        }
    }
}
