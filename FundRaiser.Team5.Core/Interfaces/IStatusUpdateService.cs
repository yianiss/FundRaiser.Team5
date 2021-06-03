using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Options;

namespace FundRaiser_Team5.Interfaces
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
