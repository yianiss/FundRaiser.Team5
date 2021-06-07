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
    public class ImagePathService:IImagePathService
    {
        private readonly IApplicationDbContext _context;

        private readonly ILogger<ImagePathService> _logger;

        public ImagePathService(IApplicationDbContext context, ILogger<ImagePathService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<OptionImagePath>> CreateImagePathAsync(OptionImagePath options)
        {
            if (options == null)
            {
                return new Result<OptionImagePath>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(options.Image))
            {
                return new Result<OptionImagePath>(ErrorCode.BadRequest, "Not Image selected.");
            }

            var project = await _context.Projects.FindAsync(options.ProjectId);

            var newImagePath = new ImagePath
            {
                Image = options.Image,
                Project = project
            };

            await _context.ImagePaths.AddAsync(newImagePath);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionImagePath>(ErrorCode.InternalServerError, "Could not save Image.");
            }

            return new Result<OptionImagePath>
            {
                Data = options
            };
        }

        public async Task<Result<int>> DeleteImagePathByIdAsync(int id)
        {
            var imageToDelete = await _context
                .ImagePaths
                .SingleOrDefaultAsync(img => img.ImagePathId == id);

            if (imageToDelete == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Image with id #{id} not found.");
            }

            _context.ImagePaths.Remove(imageToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete image.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<OptionImagePath>> GetImagePathByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<OptionImagePath>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var image = await _context
                .ImagePaths
                .SingleOrDefaultAsync(img => img.ImagePathId == id);

            if (image == null)
            {
                return new Result<OptionImagePath>(ErrorCode.NotFound, $"Image with id #{id} not found.");
            }

            return new Result<OptionImagePath>
            {
                Data = new OptionImagePath(image)
            };
        }

        public async Task<Result<List<OptionImagePath>>> GetImagePathsAsync()
        {
            var imagePaths = await _context.ImagePaths.ToListAsync();

            List<OptionImagePath> optionImagePaths = new();

            imagePaths.ForEach(img => optionImagePaths.Add(new OptionImagePath(img)));

            return new Result<List<OptionImagePath>>
            {
                Data = optionImagePaths.Count > 0 ? optionImagePaths : new List<OptionImagePath>()
            };
        }
    }
}
