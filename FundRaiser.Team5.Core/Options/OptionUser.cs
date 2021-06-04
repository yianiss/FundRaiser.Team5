using FundRaiser.Team5.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser.Team5.Core.Options
{
    public class OptionUser
    { 
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<FundingPackage> FundingPackages { get; set; }

        public List<Project> Projects { get; set; }

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
                IsActive = user.IsActive;
            }
        }
        
        public User GetUser()
        {
            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                IsActive = true
            };

            return user;
        }
    }
}
