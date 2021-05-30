using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using Microsoft.Extensions.Logging;

namespace FundRaiser_Team5.Services
{
    class StatusUpdateService : IStatusUpdateService
    {
        //private readonly IApplicationDbContext _context;
        private readonly ILogger<StatusUpdateService> _logger;

        public StatusUpdateService(/*IApplicationDbContext context,*/ ILogger<StatusUpdateService> logger)
        {
        //    _context = context;
            _logger = logger;
        }

        public Task<StatusUpdate> CreateStatusUpdateAsync(OptionStatusUpdate options)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUpdateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetStatusUpdateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusUpdate>> GetStatusUpdatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StatusUpdate> UpdateStatusUpdateAsync(OptionStatusUpdate options)
        {
            throw new NotImplementedException();
        }
    }
}
