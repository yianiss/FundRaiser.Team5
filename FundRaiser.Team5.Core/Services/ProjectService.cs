using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Entities;
using Microsoft.Extensions.Logging;

namespace FundRaiser.Team5.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _context;

        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IApplicationDbContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<OptionProject>> CreateProjectAsync(OptionProject optionProject)
        {
            if (optionProject == null)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Null Options.");
            }

            if (string.IsNullOrWhiteSpace(optionProject.Title) || string.IsNullOrWhiteSpace(optionProject.Description))
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Not all required Project Options provided.");
            }

            var project_category = Enum.IsDefined(typeof(Category), optionProject.Category);

            if (!project_category)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Category doesn't exist.");
            }

            if (optionProject.FundingGoal <= 0)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Funding goal cannot be less than or equal to zero.");
            }

            if (optionProject.CurrentFund < 0)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Current fund cannot be less than or equal to zero.");
            }

            if (optionProject.Deadline <= optionProject.DateCreated)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Deadline must be later than created date.");
            }

            User dbUser = _context.Users.Find(optionProject.UserId);

            if (dbUser == null)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "You must log in.");
            }

            var newProject = optionProject.GetProject();

            await _context.Projects.AddAsync(newProject);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionProject>(ErrorCode.InternalServerError, "Could not save Project.");
            }

            return new Result<OptionProject>
            {
                Data = new OptionProject(newProject)
            };
        }

        public async Task<Result<OptionProject>> GetProjectByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var project = await _context.Projects.SingleOrDefaultAsync(pro => pro.ProjectId == id);

            if (project == null)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, $"Product with d #{id} not found.");
            }

            return new Result<OptionProject>
            {
                Data = new OptionProject( project)
            };
        }

        public async Task<Result<int>> DeleteProjectByIdAsync(int id)
        {
            var projectToDelete = await GetProjectByIdAsync(id);

            if (projectToDelete.Error != null || projectToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Project with id #{id} not found.");
            }

            projectToDelete.Data.IsActive = false;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete project.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<List<OptionProject>>> GetProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();

            List<OptionProject> optionProjects = new();

            projects.ForEach(project => optionProjects.Add(new OptionProject(project)));

            return new Result<List<OptionProject>>
            {
                Data = projects.Count > 0 ? optionProjects : new List<OptionProject>()
            };
        }
    }
}
