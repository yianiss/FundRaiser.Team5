using FundRaiser_Team5.Data;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using FundRaiser_Team5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Scenario
{
    class CreatingUsers
    {
        public static void InsertUser ()
        {
            OptionUser user = new OptionUser() { FirstName = "Yianis", LastName = "Karopoulos" };

            using FrDbContext db = new();
            IUserService userService = new UserService(db);

            OptionUser OptionUserResult = userService.CreateUser(user);

            Console.WriteLine(OptionUserResult.UserId);
        }
    }
}
