using FundRaiser_Team5.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(OptionUser optionUser);
       
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserAsync(OptionUser optionUser);

        public Task<User> UpdateUserAsync(OptionUser optionUser, int id);

        public Task<int> DeleteUserByIdAsync(int id);
    }
}
