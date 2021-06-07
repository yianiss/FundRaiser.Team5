using FundRaiser.Team5.Api.Dtos;
using FundRaiser.Team5.Api.Interfaces;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FundRaiser.Team5.Api.Dtos.HomeDto;

namespace FundRaiser.Team5.Api.Services
{
    public class HomeDtoService : IHomeDtoService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<HomeDtoService> _logger;

        public HomeDtoService(IApplicationDbContext context, ILogger<HomeDtoService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<HomeDto>> GetHomeDtoDetailsAsync(int userId)
        {
            HomeDto _HomeDto = new() { UserId=0, UserFulltName=""};
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
