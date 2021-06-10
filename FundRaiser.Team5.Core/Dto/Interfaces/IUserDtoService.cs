using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Dto.Interfaces
{
    public interface IUserDtoService
    {
        public Task<Result<UserDto>> GetUserDtoDetailsAsync(int UserId);
    }
}
