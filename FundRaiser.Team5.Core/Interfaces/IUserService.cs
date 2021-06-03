using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Core.Interfaces
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
