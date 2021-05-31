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
        public Task<User> CreateUserAsync(OptionUser options);

        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserAsync(OptionUser options);

        public Task<User> UpdateUserAsync(OptionUser optionUser, int id);

        public Task<int> DeleteUserByIdAsync(int id);
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
