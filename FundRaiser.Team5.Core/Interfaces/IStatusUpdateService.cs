using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;

namespace FundRaiser_Team5.Interfaces
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
