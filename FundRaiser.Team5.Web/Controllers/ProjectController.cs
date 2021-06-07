using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Services;
using Microsoft.AspNetCore.Hosting;

namespace FundRaiserMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProjectService _projectService;
        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var optionProjects = await _projectService.GetProjectsAsync();
            return View(optionProjects.Data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectService.GetProjectByIdAsync(id.Value);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public ActionResult Create()
        {
            return View();
        }

       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Title,Category,Description,FundingPackages,Images,Videos,StatusUpdates,FundingGoal,CurrentFund,DateCreated, Deadline,Users")] OptionProject project)
        {

            if (ModelState.IsValid)
            {
                await _projectService.CreateProjectAsync(new OptionProject
                {
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    Category = project.Category,
                    Description = project.Description,
                    FundingPackages = project.FundingPackages,
                    Images = project.Images,
                    Videos = project.Videos,
                    StatusUpdates = project.StatusUpdates,
                    FundingGoal = project.FundingGoal,
                    CurrentFund = project.CurrentFund,
                    DateCreated = project.DateCreated,
                    Deadline = project.Deadline,
                    UserId = project.UserId
                });

                return RedirectToAction("Create","FundingPackage");
            }
            return View();
        }


        //GET: project/id/edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectService.GetProjectByIdAsync(id.Value);

            if (project.Error != null || project.Data == null)
            {
                return NotFound();
            }

            return View(project.Data);
        }

        // POST: project/id/edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("ProjectId,Title,Category,Description,FundingPackages,Images,Videos,StatusUpdates,FundingGoal,CurrentFund,DateCreated, Deadline,Users")] OptionProject optionProject)
        {
            await _projectService.EditProjectAsync(optionProject.ProjectId, optionProject);

            return RedirectToAction("Details");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectService.GetProjectByIdAsync(id.Value);

            if (project.Error != null || project.Data == null)
            {
                return NotFound();
            }

            return View(project.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectService.DeleteProjectByIdAsync(id);

            return RedirectToAction(nameof(Index));

        }

        public async Task<ActionResult> SearchByCategory([Bind("Category")] OptionProject optionProject)
        {

            var projectsResult = await _projectService.GetProjectsByCategory(optionProject);

            if (projectsResult.Error != null)
            {
                return NotFound();
            }

            return View(projectsResult.Data);
        }

        public async Task<ActionResult> SearchBySearchBar([Bind("search")] string search)
        {

            var projectsResult = await _projectService.GetProjectsBySearch(search);

            if (projectsResult.Error != null)
            {
                return NotFound();
            }

            return View(projectsResult.Data);
        }

    }

}
