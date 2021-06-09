using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Dto.Entities;
using FundRaiser_Team5.Dto.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FundRaiser_Team5.Dto.Entities.HomeDto;
using static FundRaiser_Team5.Dto.Entities.ProjectDto;

namespace FundRaiser_Team5.Dto.Services
{
    class ProjectDtoService : IProjectDtoService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectDtoService> _logger;

        public ProjectDtoService(IApplicationDbContext context, ILogger<ProjectDtoService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<ProjectDto>> GetProjectDtoDetailsAsync(int userId, int projectId)
        {
            ProjectDto _projectDto = new() { UserId = 0, UserFulltName = "" };
            User dbUser;
            if (userId > 0)
            {
                dbUser = await _context.Users.SingleOrDefaultAsync(user => user.UserId == userId);
                if (dbUser != null)
                {
                    _projectDto.UserId = dbUser.UserId;
                    _projectDto.UserFulltName = dbUser.FirstName + " " + dbUser.LastName;
                }
            }
            if (projectId <= 0)
            {
                return new Result<ProjectDto>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var project = await _context.Projects.SingleOrDefaultAsync(pro => pro.ProjectId == projectId);

            if (project == null)
            {
                return new Result<ProjectDto>(ErrorCode.BadRequest, $"Product with d #{projectId} not found.");
            }
            var dbProject = await _context.Projects.SingleOrDefaultAsync(project => project.ProjectId == projectId);

            _projectDto.ProjectId = dbProject.ProjectId;
            _projectDto.Title = dbProject.Title;
            _projectDto.Category = dbProject.Category;
            _projectDto.Description = dbProject.Description;
            _projectDto.FundingGoal = dbProject.FundingGoal;
            _projectDto.CurrentFund = dbProject.CurrentFund;
            _projectDto.DateCreated = dbProject.DateCreated;
            _projectDto.Deadline = dbProject.Deadline;
            _projectDto.CreatorId = dbProject.User.UserId;
            _projectDto.CreatorFulltName = dbProject.User.FirstName + " " + dbProject.User.LastName;

            _projectDto.FundingPackages = new();
            dbProject.FundingPackages.ForEach(FundingPackage => _projectDto.FundingPackages.Add(new fundingPackageDetails()
            {
                FundingPackageId = FundingPackage.FundingPackageId,
                Title = FundingPackage.Title,
                Description = FundingPackage.Description,
                MinPrice = FundingPackage.MinPrice
            }));

            return new Result<ProjectDto>
            {
                Data = _projectDto
            };
        }
    }
}
