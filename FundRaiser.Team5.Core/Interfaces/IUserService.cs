using FundRaiser_Team5.Entities;
using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Interfaces
{
    public interface IUserService
    {
        public Task<Result<OptionUser>> CreateUserAsync(OptionUser optionUser);
       
        public Task<Result<List<OptionUser>>> GetUsersAsync();
        public Task<Result<OptionUser>> GetUserByIdAsync(int id);
        public Task<Result<List<OptionUser>>> GetUserAsync(OptionUser optionUser);

        public Task<Result<OptionUser>> UpdateUserAsync(OptionUser optionUser, int id);

        public Task<Result<int>> DeleteUserByIdAsync(int id);
    }
}
