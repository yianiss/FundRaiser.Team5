﻿using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Dto.Interfaces
{
    interface IHomeService
    {
        public Task<Result<HomeDto>> GetHomeDtoDetailsAsync(int UserId);
    }
}