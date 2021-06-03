using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundRaiser_Team5.Services
{
    public class ProjectService : IProjectInterface
    {
        private readonly IDbContext _context;

        public ProjectService(IDbContext context)
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
            if(id<=0)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var project = await _context.Projects.SingleOrDefaultAsync(pro => pro.ProjectId == id);

            if(project==null)
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

    private FrDbContext db;
    public ProjectService(FrDbContext _db)
    {
        db = _db;
    }

    public OptionProject CreateProject(OptionProject optionProject)
    {
        if (optionProject == null)
        {
            return null;
        }

        if (optionProject.Title == null)
        {
            return null;
        }

        Project project = optionProject.GetProject();
        db.Projects.Add(project);
        db.SaveChanges();
            return new OptionProject(project);
    }

   
    public List<OptionProject> ReadProject()
    {
        // using FrDbContext db = new();
        List<Project> projects = db.Projects.ToList();
        List<OptionProject> optionProject = new List<OptionProject>();
        projects.ForEach(project => optionProject.Add(new OptionProject(project)));
        return optionProject;
    }

    public OptionProject ReadProject(int ProjectId)
    {
        Project project = db.Projects.Find(ProjectId);
        if (project == null)
        {
            return null;
        }
        return new OptionProject(project);
    }

    public List<OptionProject> ReadProject(OptionProject optionProject,string str)
        {

        List<Project> projects = db.Projects
            .Where(project => project.Description.Contains(str))
            .Where(project => project.Category.Equals(optionProject.Category))
            .ToList();

        List<OptionProject> optionProjects= new List<OptionProject>();

        projects.ForEach(project => optionProjects.Add(new OptionProject(project)));
        return optionProjects;
    }

    public OptionProject UpdateProject(int ProjectId)
    {

        Project DbProject = db.Projects.Find(ProjectId);

        if (DbProject == null)
        {
            return null;
        }

        //DbUser.Email = optionUser.Email;
      
        db.SaveChanges();

        return new OptionProject(DbProject);
    }

    public bool DeleteProject(int ProjectId)
    {

        Project DbProject = db.Projects.Find(ProjectId);
        if (DbProject == null)
        {
            return false;
        }
        else
        {
            db.Projects.Remove(DbProject);
        }
        return true;
    }
}
}
