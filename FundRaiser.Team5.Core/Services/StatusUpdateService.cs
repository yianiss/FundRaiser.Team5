using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundRaiser.Team5.Core.Services
{
    public class StatusUpdateService : IStatusUpdateService
    {
        private readonly IApplicationDbContext _context;

        private readonly ILogger<StatusUpdateService> _logger;
        
        public StatusUpdateService(IApplicationDbContext context, ILogger<StatusUpdateService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<OptionStatusUpdate>> CreateStatusUpdateAsync(OptionStatusUpdate optionStatusUpdate)
        {
            if (optionStatusUpdate == null)
            {
                return new Result<OptionStatusUpdate>(ErrorCode.BadRequest, "Null StatusUpdate options.");
            }

            if(string.IsNullOrWhiteSpace(optionStatusUpdate.Title) || string.IsNullOrWhiteSpace(optionStatusUpdate.Text))
            {
                return new Result<OptionStatusUpdate>(ErrorCode.BadRequest, $"Title or Text was empty (required)!");
            }

            StatusUpdate newStatusUpdate = new()
            {
                Title = optionStatusUpdate.Title,
                Text = optionStatusUpdate.Text,
            };

            await _context.StatusUpdates.AddAsync(newStatusUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionStatusUpdate>(ErrorCode.InternalServerError, "Could not save status Update.");
            }

            return new Result<OptionStatusUpdate>
            {
                Data = new OptionStatusUpdate(newStatusUpdate)
            };
        }

        public async Task<Result<OptionStatusUpdate>> GetStatusUpdateByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<OptionStatusUpdate>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            StatusUpdate statusUpdate = await _context
                .StatusUpdates
                .SingleOrDefaultAsync(stu => stu.StatusUpdateId == id);

            if (statusUpdate == null)
            {
                return new Result<OptionStatusUpdate>(ErrorCode.NotFound, $"StatusUpdate with id #{id} not found.");
            }

            return new Result<OptionStatusUpdate>
            {
                Data = new OptionStatusUpdate(statusUpdate)
            };
        }

        public async Task<Result<int>> DeleteStatusUpdateByIdAsync(int id)
        {
            //var statusUpdateToDelete = await GetStatusUpdateByIdAsync(id);

            //if (statusUpdateToDelete.Error != null || statusUpdateToDelete.Data == null)
            //{
            //    return new Result<int>(ErrorCode.NotFound, $"Status update with ID={id} not found");
            //}

            //_context.
            //StatusUpdates.
            //Remove(statusUpdateToDelete.Data);

            if (id <= 0)
            {
                return new Result<int>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            StatusUpdate dbStatusUpdate = await _context.StatusUpdates.SingleOrDefaultAsync(statusUpdate => statusUpdate.StatusUpdateId == id);

            if (dbStatusUpdate == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Status Update with id #{id} not found.");
            }

            dbStatusUpdate.IsActive = false;

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

        public async Task<Result<List<OptionStatusUpdate>>> GetStatusUpdatesAsync()
        {
            List<StatusUpdate> statusUpdates = await _context.StatusUpdates.ToListAsync();

            List<OptionStatusUpdate> optionStatusUpdates = new();

            statusUpdates.ForEach(statusUpdate => optionStatusUpdates.Add(new OptionStatusUpdate(statusUpdate)));

            return new Result<List<OptionStatusUpdate>>
            {
                Data = optionStatusUpdates
            };
        }

        public async Task<Result<OptionStatusUpdate>> UpdateStatusUpdateAsync(OptionStatusUpdate options)
        {
            var statusUpdateToUpdate = await GetStatusUpdateByIdAsync(options.StatusUpdateId);

            if (statusUpdateToUpdate.Error != null || statusUpdateToUpdate.Data == null)
            {
                return new Result<OptionStatusUpdate>(ErrorCode.NotFound, $"Status update with ID={options.StatusUpdateId} not found");
            }

            if (options == null)
            {
                return new Result<OptionStatusUpdate>(ErrorCode.BadRequest, "Status Update option is null");
            }

            if (string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Text))
            {
                return new Result<OptionStatusUpdate>(ErrorCode.BadRequest, $"Status Update requires a title and a text!");
            }

            statusUpdateToUpdate.Data.Title = options.Title;
            statusUpdateToUpdate.Data.Text = options.Text;

            // ToDO:
          /*  _context.
            StatusUpdates.
            Update(statusUpdateToUpdate.Data);*/

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionStatusUpdate>(ErrorCode.InternalServerError, "Could not update status update.");
            }

              return new Result<StatusUpdate>
              {
                  Data = statusUpdateToUpdate.Data
              };
        }
    }
}
