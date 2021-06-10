using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Core.Services
{
    public class UserFundingPackageService : IUserFundingPackageService
    {
        private readonly IApplicationDbContext _context;

        private readonly ILogger<UserFundingPackageService> _logger;

        public UserFundingPackageService(IApplicationDbContext context, ILogger<UserFundingPackageService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<OptionUserFundingPackage>> CreateUserFundingPackageAsync(OptionUserFundingPackage optionUserFundingPackage)
        {
            if (optionUserFundingPackage == null)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.BadRequest, "Null options.");
            }

            if (optionUserFundingPackage.UserId <= 0 ||
                optionUserFundingPackage.FundingPackageId <= 0 ||
                optionUserFundingPackage.Price < 0)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.BadRequest, "Not all required UserFundingPackage options provided.");
            }

            FundingPackage dbFundingPackage = await _context.FundingPackages.SingleOrDefaultAsync(fundingPackage => fundingPackage.FundingPackageId == optionUserFundingPackage.FundingPackageId);

            User dbUser = await _context.Users.SingleOrDefaultAsync(user => user.UserId == optionUserFundingPackage.UserId);

            var dbProject = _context.Projects;

            var project = await dbProject.SingleOrDefaultAsync(pro => pro.ProjectId == dbFundingPackage.Project.ProjectId);

            if (dbFundingPackage == null)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.NotFound, $"FundingPackage with id #{optionUserFundingPackage.FundingPackageId} not found.");
            }

            if (dbUser == null)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.NotFound, $"User with id #{optionUserFundingPackage.UserId} not found.");
            }

            if (dbFundingPackage.NumberOfAvailablePackages <= 0)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.NotFound, $"This Funding Package with id #{optionUserFundingPackage.FundingPackageId} is no longer available.");
            }

            if (project == null)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.NotFound, $"User with id #{optionUserFundingPackage.UserId} not found.");
            }

            UserFundingPackage userFundingPackage = optionUserFundingPackage.GetUserFundingPackage();

            await _context.UserFundingPackages.AddAsync(userFundingPackage);

            dbFundingPackage.NumberOfAvailablePackages -= 1;

            project.CurrentFund += optionUserFundingPackage.Price;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionUserFundingPackage>(ErrorCode.InternalServerError, "Could not save UserFundingPackage.");
            }

            return new Result<OptionUserFundingPackage>
            {
                Data = new OptionUserFundingPackage( userFundingPackage)
            };
        }

        public async Task<Result<int>> DeleteUserFundingPackageAsync(int userFundingPackageId)
        {
            if (userFundingPackageId <= 0)
            {
                return new Result<int>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            UserFundingPackage dbUserFundingPackage = await _context.UserFundingPackages.SingleOrDefaultAsync(userFundingPackage => userFundingPackage.UserFundingPackageId == userFundingPackageId);
            if (dbUserFundingPackage == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"FundingPackage with id #{userFundingPackageId} not found.");
            }
            dbUserFundingPackage.IsActive = false;
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
                Data = userFundingPackageId
            };
        }

        public async Task<Result<int>> GetTotalPriceByProjectId(int projectId)
        {
            var totalFunds =  await _context.UserFundingPackages.Where(userFundingPackage => userFundingPackage.FundingPackage.Project.ProjectId == projectId).Select(priice=> priice.Price).SumAsync();

            return new Result<int>
            {
                Data = totalFunds
            };
        }

        public async Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackageAsync()
        {
            List<UserFundingPackage> userFundingPackages = await _context.UserFundingPackages.ToListAsync();

            List<OptionUserFundingPackage> optionUserFundingPackages = new();

            userFundingPackages.ForEach(userFundingPackage => optionUserFundingPackages.Add(new OptionUserFundingPackage(userFundingPackage)));

            return new Result<List<OptionUserFundingPackage>>
            {
                Data = optionUserFundingPackages.Count > 0 ? optionUserFundingPackages : new List<OptionUserFundingPackage>()
            };
        }

        public async Task<Result<OptionUserFundingPackage>> ReadUserFundingPackageAsync(int userFundingPackageId)
        {
            if (userFundingPackageId <= 0)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            UserFundingPackage dbUserfundingPackage = await _context.UserFundingPackages.SingleOrDefaultAsync(userFundingPackage => userFundingPackage.UserFundingPackageId == userFundingPackageId);

            if (dbUserfundingPackage == null)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.NotFound, $"UserFundingPackage with id #{userFundingPackageId} not found.");
            }

            return new Result<OptionUserFundingPackage>
            {
                Data = new OptionUserFundingPackage(dbUserfundingPackage)
            };
        }

        public async Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackageAsync(OptionUserFundingPackage optionUserFundingPackage)
        {
            // Microsoft.EntityFrameworkCore.DbSet<UserFundingPackage> dbUserFundingPackages = _context.UserFundingPackages;
            var dbUserFundingPackages = _context.UserFundingPackages;
            if (!(optionUserFundingPackage.UserId <= 0))
                dbUserFundingPackages.Where(userFundingPackage => userFundingPackage.User.UserId.Equals(optionUserFundingPackage.UserId));
            if (!(optionUserFundingPackage.FundingPackageId <= 0))
                dbUserFundingPackages.Where(userFundingPackage => userFundingPackage.FundingPackage.FundingPackageId.Equals(optionUserFundingPackage.FundingPackageId));
            List<UserFundingPackage> userFundingPackages = await dbUserFundingPackages.ToListAsync();
            List<OptionUserFundingPackage> optionUserFundingPackages = new();
            userFundingPackages.ForEach(userFundingPackage => optionUserFundingPackages.Add(new OptionUserFundingPackage(userFundingPackage)));

            return new Result<List<OptionUserFundingPackage>>
            {
                Data = optionUserFundingPackages
            };
        }

        public async Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackagesByProjectIdAsync(int projectId)
        {
            if (projectId <= 0)
            {
                return new Result<List<OptionUserFundingPackage>>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            List<UserFundingPackage> dbUserFundingPackages = await _context.UserFundingPackages.Where(userFundingPackage => userFundingPackage.FundingPackage.Project.ProjectId == projectId).ToListAsync(); ;

            List<OptionUserFundingPackage> optionUserFundingPackages = new();

            dbUserFundingPackages.ForEach(userFundingPackage => optionUserFundingPackages.Add(new OptionUserFundingPackage(userFundingPackage)));

            return new Result<List<OptionUserFundingPackage>>
            {
                Data = optionUserFundingPackages
            };
        }

        public async Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackagesByUsertIdAsync(int UserId)
        {
            if (UserId <= 0)
            {
                return new Result<List<OptionUserFundingPackage>>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            List<UserFundingPackage> dbUserFundingPackages = await _context.UserFundingPackages.Where(userFundingPackage => userFundingPackage.User.UserId == UserId).ToListAsync(); ;

            List<OptionUserFundingPackage> optionUserFundingPackages = new();

            dbUserFundingPackages.ForEach(userFundingPackage => optionUserFundingPackages.Add(new OptionUserFundingPackage(userFundingPackage)));

            return new Result<List<OptionUserFundingPackage>>
            {
                Data = optionUserFundingPackages
            };
        } 

        public async Task<Result<OptionUserFundingPackage>> UpdateUserFundingPackageAsync(int userFundingPackageId, OptionUserFundingPackage optionUserFundingPackage)
        {
            if (userFundingPackageId <= 0)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            UserFundingPackage dbUserFundingPackage = await _context.UserFundingPackages.SingleOrDefaultAsync(userFundingPackage => userFundingPackage.UserFundingPackageId == userFundingPackageId);

            if (dbUserFundingPackage == null)
            {
                return new Result<OptionUserFundingPackage>(ErrorCode.NotFound, $"FundingPackage with id #{userFundingPackageId} not found.");
            }

            dbUserFundingPackage.Price = optionUserFundingPackage.Price;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<OptionUserFundingPackage>(ErrorCode.InternalServerError, "Could not save OptionUserFundingPackage.");
            }

            return new Result<OptionUserFundingPackage>
            {
                Data = new OptionUserFundingPackage(dbUserFundingPackage)
            };
        }
    }
}
