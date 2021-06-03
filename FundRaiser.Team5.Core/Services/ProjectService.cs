using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FundRaiser_Team5.Model;
using FundRaiser_Team5.Entities;

namespace FundRaiser_Team5.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _context;

        public ProjectService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Project>> CreateProjectAsync(OptionProject options)
        {
            if (options == null)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Null Options.");
            }

            if (string.IsNullOrWhiteSpace(options.Title) || string.IsNullOrWhiteSpace(options.Description))
            {
                return new Result<Project>(ErrorCode.BadRequest, "Not all required Project Options provided.");
            }

            var project_category = Enum.IsDefined(typeof(Model.Category), options.Category);

            if (!project_category)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Category doesnt exist.");
            }

            if (options.FundingGoal <= 0)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Funding goal cannot be less than or equal to zero.");
            }

            if (options.CurrentFund < 0)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Current fund cannot be less than or equal to zero.");
            }

            if (options.Deadline <= options.DateCreated)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Deadline must be later than created date.");
            }

            var newProject = new Project
            {
                Title = options.Title,
                Description = options.Description,
                Category = options.Category,
                Images = options.Images,
                Videos = options.Videos,
                StatusUpdates = options.StatusUpdates,
                FundingGoal = options.FundingGoal,
                CurrentFund = options.CurrentFund,
                DateCreated = options.DateCreated,
                Deadline = options.Deadline
            };

            await _context.Projects.AddAsync(newProject);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result<Project>(ErrorCode.InternalServerError, "Could not save Project.");
            }

            return new Result<Project>
            {
                Data = newProject
            };
        }

        public async Task<Result<Project>> GetProjectByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var project = await _context.Projects.SingleOrDefaultAsync(pro => pro.ProjectId == id);

            if (project == null)
            {
                return new Result<Project>(ErrorCode.BadRequest, $"Product with d #{id} not found.");
            }

            return new Result<Project>
            {
                Data = project
            };
        }
        public async Task<Result<int>> DeleteProjectByIdAsync(int id)
        {
            var projectToDelete = await GetProjectByIdAsync(id);

            if (projectToDelete.Error != null || projectToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Project with id #{id} not found.");
            }

            _context.Projects.Remove(projectToDelete.Data);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result<int>(ErrorCode.InternalServerError, "Could not delete project.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<List<Project>>> GetProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();

            return new Result<List<Project>>
            {
                Data = projects.Count > 0 ? projects : new List<Project>()
            };
        }
    }
}
