using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundRaiser_Team5.Services
{
    public class VideoPathService:IVideoPathService
    {
        private readonly IApplicationDbContext _context;

        private readonly ILogger<VideoPathService> _logger;

        public VideoPathService(IApplicationDbContext context, ILogger<VideoPathService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<OptionVideoPath>> CreateVideoPathAsync(OptionVideoPath options)
        {
            if (options == null)
            {
                return new Result<OptionVideoPath>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(options.Video))
            {
                return new Result<OptionVideoPath>(ErrorCode.BadRequest, "Not Video selected.");
            }

            var project = await _context.Projects.FindAsync(options.ProjectId);

            var newVideoPath = new VideoPath
            {
                Video = options.Video,
                Project = project
            };

            await _context.VideoPaths.AddAsync(newVideoPath);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionVideoPath>(ErrorCode.InternalServerError, "Could not save Video.");
            }

            return new Result<OptionVideoPath>
            {
                Data = options
            };
        }

        public async Task<Result<int>> DeleteVideoPathByIdAsync(int id)
        {
            var videoToDelete = await _context
                .VideoPaths
                .SingleOrDefaultAsync(vid => vid.VideoPathId == id);

            if (videoToDelete == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Video with id #{id} not found.");
            }

            _context.VideoPaths.Remove(videoToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete video.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<OptionVideoPath>> GetVideoPathByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<OptionVideoPath>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var video = await _context
                .VideoPaths
                .SingleOrDefaultAsync(vid => vid.VideoPathId == id);

            if (video == null)
            {
                return new Result<OptionVideoPath>(ErrorCode.NotFound, $"Video with id #{id} not found.");
            }

            return new Result<OptionVideoPath>
            {
                Data = new OptionVideoPath(video)
            };
        }

        public async Task<Result<List<OptionVideoPath>>> GetVideoPathsAsync()
        {
            var videoPaths = await _context.VideoPaths.ToListAsync();

            List<OptionVideoPath> optionVideoPaths = new();

            videoPaths.ForEach(vid => optionVideoPaths.Add(new OptionVideoPath(vid)));

            return new Result<List<OptionVideoPath>>
            {
                Data = optionVideoPaths.Count > 0 ? optionVideoPaths : new List<OptionVideoPath>()
            };
        }
    }
}
