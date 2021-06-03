using FundRaiser_Team5.Model;
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
        public Task<Result<User>> CreateUserAsync(OptionUser optionUser);
       
        public Task<Result<List<User>>> GetUsersAsync();
        public Task<Result<User>> GetUserByIdAsync(int id);
        public Task<Result<User>> GetUserAsync(OptionUser optionUser);


        public Task<Result<User>> UpdateUserAsync(OptionUser optionUser, int id);

        public Task<Result<int>> DeleteUserByIdAsync(int id);
    }
}
