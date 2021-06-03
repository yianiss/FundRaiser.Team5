using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;

namespace FundRaiser.Team5.Core.Interfaces
{
    public interface IStatusUpdateService
    {
        Task<Result<List<StatusUpdate>>> GetStatusUpdatesAsync();

        Task<Result<StatusUpdate>> CreateStatusUpdateAsync(OptionStatusUpdate options);

        Task<Result<StatusUpdate>> GetStatusUpdateByIdAsync(int id);

        Task<Result<StatusUpdate>> UpdateStatusUpdateAsync(OptionStatusUpdate options);

        Task<Result<int>> DeleteStatusUpdateByIdAsync(int id);
    }
}
