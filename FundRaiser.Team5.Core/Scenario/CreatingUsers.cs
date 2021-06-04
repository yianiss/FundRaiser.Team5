using FundRaiser.Team5.Core.Options;

namespace FundRaiser.Team5.Core.Scenario
{
    class CreatingUsers
    {
        public static void InsertUser ()
        {
            OptionUser user = new OptionUser() { FirstName = "Yianis", LastName = "Karopoulos" };

           // using FrDbContext db = new();
          //  IUserService userService = new UserService(db);

          //  OptionUser OptionUserResult = userService.CreateUser(user);

           // Console.WriteLine(OptionUserResult.UserId);
        }
    }
}
