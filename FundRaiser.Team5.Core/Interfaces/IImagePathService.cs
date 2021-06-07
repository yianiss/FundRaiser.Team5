using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Options;

namespace FundRaiser_Team5.Interfaces
{
    public interface IImagePathService
    {
        Task<Result<List<OptionImagePath>>> GetImagePathsAsync();

        Task<Result<OptionImagePath>> CreateImagePathAsync(OptionImagePath options);

        Task<Result<OptionImagePath>> GetImagePathByIdAsync(int id);

        Task<Result<int>> DeleteImagePathByIdAsync(int id);

    }
}
