using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Linq;

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

        public async Task<Result<List<OptionProject>>> GetProjectsByCategory(Category category)
        {
            var projects = await GetProjectsAsync();

            if (projects.Error != null)
            {
                return new Result<List<OptionProject>>(ErrorCode.BadRequest, "There was an error");
            }

            var projectsByCategory = projects.Data.Where(pro => pro.Category == category).ToList();

            return new Result<List<OptionProject>>
            {
                Data = projectsByCategory.Count > 0 ? projectsByCategory : new List<OptionProject>()
            };
        }

        public async Task<Result<List<OptionProject>>> GetProjectsBySearch(string search)
        {
            var projects = await GetProjectsAsync();

            if (projects.Error != null)
            {
                return new Result<List<OptionProject>>(ErrorCode.BadRequest, "There was an error");
            }

            var projectsBySearch = projects.Data.Where(pro => pro.Title.Contains(search)).ToList()
                .Union
                (projects.Data.Where(pro => pro.Description.Contains(search)).ToList()).ToList();

            return new Result<List<OptionProject>>
            {
                Data = projectsBySearch.Count > 0 ? projectsBySearch : new List<OptionProject>()
            };
        }

        public async Task<Result<OptionProject>> EditProjectAsync(int projectId, OptionProject options)
        {
            var dbProjects = _context.Projects;

            Project ProjectToEdit = await dbProjects.FindAsync(projectId);


            if (ProjectToEdit == null)
            {
                return new Result<OptionProject>(ErrorCode.NotFound, $"Project with ID={projectId} not found");
            }

            if (options == null)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Project option is null");
            }

            if (string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Description))
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, $"Project requires a title, a description, a deadline, a funding goal!");
            }

            ProjectToEdit.Title = options.Title;
            ProjectToEdit.Deadline = options.Deadline;
            ProjectToEdit.FundingPackages = options.FundingPackages;
            ProjectToEdit.FundingGoal = options.FundingGoal;
            ProjectToEdit.Images = options.Images;
            ProjectToEdit.Videos = options.Videos;
            ProjectToEdit.Description = options.Description;


            OptionProject optionProject = new(ProjectToEdit);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionProject>(ErrorCode.InternalServerError, "Could not update project.");
            }

            return new Result<OptionProject>
            {
                Data = optionProject
            };
        }

        public async Task<Result<OptionProject>> EditProjectAsync(int projectId, decimal price)
        {
            var dbProjects = _context.Projects;

            Project ProjectToEdit = await dbProjects.FindAsync(projectId);


            if (ProjectToEdit == null)
            {
                return new Result<OptionProject>(ErrorCode.NotFound, $"Project with ID={projectId} not found");
            }

            if (price <= 0)
            {
                return new Result<OptionProject>(ErrorCode.BadRequest, "Price is zero or negative");
            }


            ProjectToEdit.CurrentFund += price;


            OptionProject optionProject = new(ProjectToEdit);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionProject>(ErrorCode.InternalServerError, "Could not update project.");
            }

            return new Result<OptionProject>
            {
                Data = optionProject
            };
        }

        public async Task<Result<List<OptionProject>>> GetActiveProjectsAsync()
        {
            var projects = await GetProjectsAsync();

            if (projects.Error != null)
            {
                return new Result<List<OptionProject>>(ErrorCode.BadRequest, "There was an error");
            }

            List<OptionProject> optionProjects = new();

            var activeProjects = projects.Data.Where(pro => pro.IsActive).ToList();

            return new Result<List<OptionProject>>
            {
                Data = activeProjects.Count > 0 ? activeProjects : new List<OptionProject>()
            };
        }

    }
}
