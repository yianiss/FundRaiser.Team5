using FundRaiser.Team5.Core.Options;
using FundRaiser_Team5.Scenario;

namespace FundRaiser.Team5.Core
{
    class Program
    {
        static void Main(string[] args)
        {

            OptionUser optionUser = new OptionUser()
            {
                LastName = "Papadopoulos"
            };


            //using FrDbContext db = new();
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
