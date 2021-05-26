using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Options;

namespace FundRaiser_Team5.Interfaces
{
    interface IStatusUpdateService
    {
        Task<List<StatusUpdate>> GetStatusUpdatesAsync();
        Task<StatusUpdate> CreateStatusUpdateAsync(OptionStatusUpdate options);
        Task<User> GetStatusUpdateByIdAsync(int id);
        Task<StatusUpdate> UpdateStatusUpdateAsync(OptionStatusUpdate options);
        Task<int> DeleteUpdateByIdAsync(int id);
    }
}
