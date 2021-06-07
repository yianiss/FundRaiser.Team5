using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Options;

namespace FundRaiser_Team5.Interfaces
{
    public interface IVideoPathService
    {
        Task<Result<List<OptionVideoPath>>> GetVideoPathsAsync();

        Task<Result<OptionVideoPath>> CreateVideoPathAsync(OptionVideoPath options);

        Task<Result<OptionVideoPath>> GetVideoPathByIdAsync(int id);

        Task<Result<int>> DeleteVideoPathByIdAsync(int id);
    }
}
