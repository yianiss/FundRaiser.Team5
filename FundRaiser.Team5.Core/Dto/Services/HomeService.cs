using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser_Team5.Dto.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FundRaiser_Team5.Dto.Entities.HomeDto;

namespace FundRaiser_Team5.Dto.Services
{
    class HomeService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<HomeService> _logger;

        public HomeService(IApplicationDbContext context, ILogger<HomeService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<HomeDto>> GetHomeDtoDetailsAsync(int userId)
        {
            HomeDto _HomeDto = new() { UserId = 0, UserFulltName = "" };
            User dbUser;
            if (userId > 0)
            {
                dbUser = await _context.Users.SingleOrDefaultAsync(user => user.UserId == userId);
                if (dbUser != null)
                {
                    _HomeDto.UserId = dbUser.UserId;
                    _HomeDto.UserFulltName = dbUser.FirstName + " " + dbUser.LastName;
                }
            }
            var projects = await _context.Projects.ToListAsync();

            List<ProjectDetails> ProjectsDetails = new();

            projects.ForEach(project => ProjectsDetails.Add(new ProjectDetails()
            {
                ProjectId = project.ProjectId,
                ProjectTitle = project.Title,
                ProjectDescription = project.Description,
                ProjectCategory = Convert.ToInt32(project.Category),//optionProject.Category;
                ProjectProgress = project.CurrentFund / project.FundingGoal,
                ProjectDeadline = project.Deadline,
                ProjectCreatorFullName = project.User.FirstName + " " + project.User.LastName
            }));
            _HomeDto.Projects = ProjectsDetails;

            return new Result<HomeDto>
            {
                Data = _HomeDto
            };
        }
    }
}
