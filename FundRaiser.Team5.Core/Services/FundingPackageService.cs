using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Services.Core.Services
{
    class FundingPackageService : IFundingPackageService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<FundingPackageService> _logger;

        public FundingPackageService(IApplicationDbContext context, ILogger<FundingPackageService> logger)

        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<OptionFundingPackage>> CreateFundingPackageAsync(OptionFundingPackage optionFundingPackage)
        {
            if (optionFundingPackage == null)
            {
                return new Result<OptionFundingPackage>(ErrorCode.BadRequest, "Null options.");
            }
            if (optionFundingPackage.ProjectId < 0 ||
                string.IsNullOrWhiteSpace(optionFundingPackage.Title) ||
                string.IsNullOrWhiteSpace(optionFundingPackage.Description) ||
                optionFundingPackage.MinPrice < 0 ||
                optionFundingPackage.AvailablePackages < -1)
            {
                return new Result<OptionFundingPackage>(ErrorCode.BadRequest, "Not all required OptionFundingPackage options provided.");
            }

            Project dbProject = _context.Projects.Find(optionFundingPackage.ProjectId);
            if (dbProject == null)
            {
                return null;
            }
            FundingPackage fundingPackage = optionFundingPackage.GetFundingPackage();
            fundingPackage.Project = dbProject;
            await _context.FundingPackages.AddAsync(fundingPackage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<OptionFundingPackage>(ErrorCode.InternalServerError, "Could not save customer.");
            }
            return new Result<OptionFundingPackage>
            {
                Data = new OptionFundingPackage(fundingPackage)
            };
        }

        public async Task<Result<int>> DeleteFundingPackageAsync(int fundingPackageId)
        {
            if (fundingPackageId <= 0)
            {
                return new Result<int>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            FundingPackage dbfundingPackage = await _context.FundingPackages.SingleOrDefaultAsync(fundingPackage => fundingPackage.FundingPackageId == fundingPackageId);
            if (dbfundingPackage == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"FundingPackage with id #{fundingPackageId} not found.");
            }

            _context.FundingPackages.Remove(dbfundingPackage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<int>(ErrorCode.InternalServerError, "Could not delete customer.");
            }

            return new Result<int>
            {
                Data = fundingPackageId
            };
            throw new NotImplementedException();
        }

        public async Task<Result<List<OptionFundingPackage>>> ReadFundingPackageAsync()
        {
            List<FundingPackage> fundingPackages = await _context.FundingPackages.ToListAsync();
            List<OptionFundingPackage> optionFundingPackages = new();
            fundingPackages.ForEach(fundingPackage => optionFundingPackages.Add(new OptionFundingPackage(fundingPackage)));

            return new Result<List<OptionFundingPackage>>
            {
                Data = optionFundingPackages.Count > 0 ? optionFundingPackages : new List<OptionFundingPackage>()
            };
        }

        public async Task<Result<OptionFundingPackage>> ReadFundingPackageAsync(int fundingPackageId)
        {
            if (fundingPackageId <= 0)
            {
                return new Result<OptionFundingPackage>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }
            FundingPackage dbfundingPackage = await _context.FundingPackages.SingleOrDefaultAsync(fundingPackage => fundingPackage.FundingPackageId == fundingPackageId);
            if (dbfundingPackage == null)
            {
                return new Result<OptionFundingPackage>(ErrorCode.NotFound, $"FundingPackage with id #{fundingPackageId} not found.");
            }

            return new Result<OptionFundingPackage>
            {
                Data = new OptionFundingPackage(dbfundingPackage)
            };
        }

        public async Task<Result<List<OptionFundingPackage>>> ReadFundingPackageAsync(OptionFundingPackage optionFundingPackage)
        {
            // Microsoft.EntityFrameworkCore.DbSet<FundingPackage> dbFundingPackages = _context.FundingPackages;
            var dbFundingPackages = _context.FundingPackages;
            if (!(optionFundingPackage.ProjectId < 0))
                dbFundingPackages.Where(fundingPackage => fundingPackage.Project.ProjectId.Equals(optionFundingPackage.ProjectId));
            if (!(string.IsNullOrWhiteSpace(optionFundingPackage.Title)))
                dbFundingPackages.Where(fundingPackage => fundingPackage.Title.Equals(optionFundingPackage.Title));
            if (!(string.IsNullOrWhiteSpace(optionFundingPackage.Description)))
                dbFundingPackages.Where(fundingPackage => fundingPackage.Description.Equals(optionFundingPackage.Description));
            if (!(optionFundingPackage.MinPrice < 0))
                dbFundingPackages.Where(fundingPackage => fundingPackage.MinPrice.Equals(optionFundingPackage.MinPrice));
            if (!(optionFundingPackage.AvailablePackages < 0))
                dbFundingPackages.Where(fundingPackage => fundingPackage.AvailablePackages.Equals(optionFundingPackage.AvailablePackages));
            List<FundingPackage> fundingPackages = await dbFundingPackages.ToListAsync();
            List<OptionFundingPackage> optionFundingPackages = new();
            fundingPackages.ForEach(fundingPackage => optionFundingPackages.Add(new OptionFundingPackage(fundingPackage)));

            return new Result<List<OptionFundingPackage>>
            {
                Data = optionFundingPackages
            };
        }

        public Result<List<OptionFundingPackage>> ReadFundingPackagesByProjectIdAsync(int projectId)
        {

            throw new NotImplementedException();
        }

        public async  Task<Result<OptionFundingPackage>> UpdateFundingPackageAsync(int fundingPackageId, OptionFundingPackage optionFundingPackage)
        {
            
            if (fundingPackageId <= 0)
            {
                return new Result<OptionFundingPackage>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }
            FundingPackage dbFundingPackage = await _context.FundingPackages.SingleOrDefaultAsync(fundingPackage => fundingPackage.FundingPackageId == fundingPackageId);
            if (dbFundingPackage == null)
            {
                return new Result<OptionFundingPackage>(ErrorCode.NotFound, $"FundingPackage with id #{fundingPackageId} not found.");
            }

            dbFundingPackage.Title = optionFundingPackage.Title;
            dbFundingPackage.Description = optionFundingPackage.Description;
            dbFundingPackage.MinPrice = optionFundingPackage.MinPrice;
            dbFundingPackage.AvailablePackages = optionFundingPackage.AvailablePackages;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<OptionFundingPackage>(ErrorCode.InternalServerError, "Could not save FundingPackage.");
            }

            return new Result<OptionFundingPackage>
            {
                Data = new OptionFundingPackage(dbFundingPackage)
            };
        }
    }
}
