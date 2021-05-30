using FundRaiser_Team5.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Interfaces
{
    public interface IUserInterface
    {
         Task<User> CreateUserAsync(OptionUser options);
         Task<List<User>> GetUsersAsync();
         Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserAsync(OptionUser options);
        Task<int> DeleteUserByIdAsync(int id);
    }

    public interface IUserService
    {
        public OptionUser CreateUser(OptionUser optionUser);

        public List<OptionUser> ReadUser();
        public OptionUser ReadUser(int UserId);
        public List<OptionUser> ReadUser(OptionUser optionUser);
        

        public OptionUser UpdateUser(OptionUser optionUser, int id);

        public bool DeleteUser(int id);

    }
    }
}
