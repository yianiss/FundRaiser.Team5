using System;
using System.Collections.Generic;
using FundRaiser_Team5.Data;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;
using FundRaiser_Team5.Services;

namespace FundRaiser_Team5
{
    class Program
    {
        static void Main(string[] args)
        {

            OptionUser optionUser = new OptionUser()
            {
                LastName = "Papadopoulos"
            };


            using FrDbContext db = new();
           /* IUserService userService = new UserService(db);

            List<OptionUser> users = userService.ReadUser(optionUser);

            users.ForEach(user => Console.WriteLine($"{user.UserId} {user.FirstName}"));
           */

           /* OptionUser optionUser = userService.ReadUser(3);

            if(optionUser.UserId != 0)
            {
                Console.WriteLine(optionUser.FirstName);
            }
            else
            {
                Console.WriteLine("not found");
            }
            */

        }
    }
}
