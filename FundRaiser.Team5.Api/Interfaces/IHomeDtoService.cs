using FundRaiser.Team5.Api.Dtos;
using FundRaiser.Team5.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Api.Interfaces
{
    interface IHomeDtoService
    {
        public Task<Result<HomeDto>> GetHomeDtoDetailsAsync(int UserId);

    }
}
