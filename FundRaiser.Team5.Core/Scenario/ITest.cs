using FundRaiser.Team5.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Scenario
{
    public interface ITest
    {
        Task<Result<int>> Createdb();
    }
}
