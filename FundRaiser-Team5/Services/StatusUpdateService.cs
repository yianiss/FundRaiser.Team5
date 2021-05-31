using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Data;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundRaiser_Team5.Services
{
    public class StatusUpdateService : IStatusUpdateService
    {
        //private readonly IApplicationDbContext _context;
        private readonly ILogger<StatusUpdateService> _logger;
        FrDbContext _context;

        public StatusUpdateService(/*IApplicationDbContext context,*/ ILogger<StatusUpdateService> logger)
        {
        //    _context = context;
            _logger = logger;
        }

        public async Task<StatusUpdate> CreateStatusUpdateAsync(OptionStatusUpdate options)
        {
            if (options == null)
            {
                _logger.LogError($"StatusUpdate option is null!");
                return null;
            }

            if(string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Text))
            {
                _logger.LogError($"Title or Text was empty (required)!");
                return null;
            }

            StatusUpdate newStatusUpdate = new()
            {
                Title = options.Title,
                Text = options.Text,
            };

            await _context.StatusUpdates.AddAsync(newStatusUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }

            return newStatusUpdate;

        }

        public async Task<StatusUpdate> GetStatusUpdateByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Id must non negative number");
                return null;
            }

            StatusUpdate statusUpdate = await _context
                .StatusUpdates
                .SingleOrDefaultAsync(stu => stu.StatusUpdateId == id);

            if (statusUpdate == null)
            {
                _logger.LogError($"StatusUpdate with id #{id} not found.");
                return null;
            }

            return statusUpdate;
        }

        public async Task<int> DeleteUpdateByIdAsync(int id)
        {
            StatusUpdate statusUpdateToDelete = await GetStatusUpdateByIdAsync(id);

            if (statusUpdateToDelete==null)
            {
                _logger.LogError($"Status update with ID={id} not found");
                return -1;
            }

            _context.
            StatusUpdates.
            Remove(statusUpdateToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return -1;
            }

            return id;
        }

        public async Task<List<StatusUpdate>> GetStatusUpdatesAsync()
        {
            List<StatusUpdate> statusUpdates = await _context.StatusUpdates.ToListAsync();

            if (statusUpdates.Count > 0)
            {
                return statusUpdates;
            }
            else
            {
                return new List<StatusUpdate>();
            }
        }

        public async Task<StatusUpdate> UpdateStatusUpdateAsync(OptionStatusUpdate options)
        {
            StatusUpdate statusUpdateToUpdate = await GetStatusUpdateByIdAsync(options.StatusUpdateId);

            if (statusUpdateToUpdate == null)
            {
                _logger.LogError($"Status update with ID={options.StatusUpdateId} not found");
                return null;
            }

            if (options == null)
            {
                _logger.LogError($"StatusUpdate option is null!");
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Text))
            {
                _logger.LogError($"Title or Text was empty (required)!");
                return null;
            }

            statusUpdateToUpdate.Title = options.Title;
            statusUpdateToUpdate.Text = options.Text;

            _context.
            StatusUpdates.
            Update(statusUpdateToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

            return statusUpdateToUpdate;

        }
    }
}
