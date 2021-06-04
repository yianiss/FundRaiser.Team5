using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;

namespace FundRaiser.Team5.Core.Interfaces
{
    public interface IStatusUpdateService
    {
        Task<Result<List<OptionStatusUpdate>>> GetStatusUpdatesAsync();
        Task<Result<OptionStatusUpdate>> CreateStatusUpdateAsync(OptionStatusUpdate options);
        Task<Result<OptionStatusUpdate>> GetStatusUpdateByIdAsync(int id);
        Task<Result<OptionStatusUpdate>> UpdateStatusUpdateAsync(OptionStatusUpdate options);
        Task<Result<int>> DeleteStatusUpdateByIdAsync(int id);
    }
}
