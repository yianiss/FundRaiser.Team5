using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser_Team5.Entities;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundRaiser_Team5.Services
{
    public class StatusUpdateService : IStatusUpdateService
    {
        //private readonly IDbContext _context;
        private readonly ILogger<StatusUpdateService> _logger;
        IApplicationDbContext _context;

        public StatusUpdateService(/*IApplicationDbContext context,*/ ILogger<StatusUpdateService> logger)
        {
        //    _context = context;
            _logger = logger;
        }

        public async Task<Result<StatusUpdate>> CreateStatusUpdateAsync(OptionStatusUpdate options)
        {
            if (options == null)
            {
                return new Result<StatusUpdate>(ErrorCode.BadRequest, "Null StatusUpdate options.");
            }

            if(string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Text))
            {
                return new Result<StatusUpdate>(ErrorCode.BadRequest, $"Title or Text was empty (required)!");
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

                return new Result<StatusUpdate>(ErrorCode.InternalServerError, "Could not save status Update.");
            } 

            return new Result<StatusUpdate>
            {
                Data = newStatusUpdate
            };
        }

        public async Task<Result<StatusUpdate>> GetStatusUpdateByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<StatusUpdate>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            StatusUpdate statusUpdate = await _context
                .StatusUpdates
                .SingleOrDefaultAsync(stu => stu.StatusUpdateId == id);

            if (statusUpdate == null)
            {
                return new Result<StatusUpdate>(ErrorCode.NotFound, $"StatusUpdate with id #{id} not found.");
            }

            return new Result<StatusUpdate>
            {
                Data = statusUpdate
            };
        }

        public async Task<Result<int>> DeleteStatusUpdateByIdAsync(int id)
        {
            var statusUpdateToDelete = await GetStatusUpdateByIdAsync(id);

            if (statusUpdateToDelete.Error != null || statusUpdateToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Status update with ID={id} not found");
            }

            _context.
            StatusUpdates.
            Remove(statusUpdateToDelete.Data);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete status update.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<List<StatusUpdate>>> GetStatusUpdatesAsync()
        {
            List<StatusUpdate> statusUpdates = await _context.StatusUpdates.ToListAsync();

            return new Result<List<StatusUpdate>>
            {
                Data = statusUpdates.Count > 0 ? statusUpdates : new List<StatusUpdate>()
            };
        }

        public async Task<Result<StatusUpdate>> UpdateStatusUpdateAsync(OptionStatusUpdate options)
        {
            var statusUpdateToUpdate = await GetStatusUpdateByIdAsync(options.StatusUpdateId);

            if (statusUpdateToUpdate.Error != null || statusUpdateToUpdate.Data == null)
            {
                return new Result<StatusUpdate>(ErrorCode.NotFound, $"Status update with ID={options.StatusUpdateId} not found");
            }

            if (options == null)
            {
                return new Result<StatusUpdate>(ErrorCode.BadRequest, "Status Update option is null");
            }

            if (string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Text))
            {
                return new Result<StatusUpdate>(ErrorCode.BadRequest, $"Status Update requires a title and a text!");
            }

            statusUpdateToUpdate.Data.Title = options.Title;
            statusUpdateToUpdate.Data.Text = options.Text;

            _context.
            StatusUpdates.
            Update(statusUpdateToUpdate.Data);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<StatusUpdate>(ErrorCode.InternalServerError, "Could not update status update.");
            }

            return new Result<StatusUpdate>
            {
                Data = statusUpdateToUpdate.Data
            };

        }
    }
}
