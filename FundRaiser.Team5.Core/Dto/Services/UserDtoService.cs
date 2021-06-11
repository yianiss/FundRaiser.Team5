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
using static FundRaiser_Team5.Dto.Entities.UserDto;

namespace FundRaiser_Team5.Dto.Services
{
    class UserDtoService : IUserDtoService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectDtoService> _logger;

        public UserDtoService(IApplicationDbContext context, ILogger<ProjectDtoService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<UserDto>> GetUserDtoDetailsAsync(int userId)
        {
            UserDto _userDto = new() { UserId = 0, UserFullName = "" };
            User dbUser;
            if (userId <= 0)
            {
                return new Result<UserDto> { Data = _userDto };
            }

            dbUser = await _context.Users.SingleOrDefaultAsync(user => user.UserId == userId);

            if (dbUser == null)
            {
                return new Result<UserDto> { Data = _userDto };
            }

            _userDto.UserId = dbUser.UserId;
            _userDto.UserFullName = dbUser.FirstName + " " + dbUser.LastName;

            _userDto.Projects = new List<ProjectDetails>();

            var projects = await _context.Projects.Where(project => project.User.UserId.Equals(dbUser.UserId)).ToListAsync();


            projects.ForEach(project => _userDto.Projects.Add(new ProjectDetails()
            {
                ProjectId = project.ProjectId,
                ProjectTitle = project.Title,
                ProjectDescription = project.Description,
                ProjectCategory = Convert.ToInt32(project.Category),
                ProjectProgress = project.CurrentFund / project.FundingGoal,
                ProjectDeadline = project.Deadline,
                ProjectCreatorFullName = project.User.FirstName + ' ' + project.User.LastName,
            })); ;

            var fundingPackages = await _context.UserFundingPackages.Where(UFP => UFP.User.UserId.Equals(dbUser.UserId)).ToListAsync();
            _userDto.MyFundingPackage = new List< FundingPackageDetails>();

            //fundingPackages.ForEach(userFundingPackage => _userDto.MyFundingPackage.Add(new FundingPackageDetails()
            //{
            //    ProjectId = userFundingPackage.FundingPackage.Project.ProjectId,
            //    TitleProject = userFundingPackage.FundingPackage.Project.Title,
            //    FundingPackageId = userFundingPackage.FundingPackage.FundingPackageId,
            //    Title = userFundingPackage.FundingPackage.Title,
            //    Description = userFundingPackage.FundingPackage.Description,
            //    Price = userFundingPackage.Price
            //}));

            return new Result<UserDto>
            {
                Data = _userDto
            };
        }
    }
}
