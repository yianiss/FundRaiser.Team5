using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Services;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System;
using FundRaiser_Team5.Dto.Entities;

namespace FundRaiserMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProjectService _projectService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private readonly IUserService _userService;

        public ProjectController(IProjectService projectService, IWebHostEnvironment hostingEnvironment, IUserService userService)
        {
            _hostingEnvironment = hostingEnvironment;
            _projectService = projectService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }

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
        public async Task<IActionResult> Create([Bind("ProjectId,Title,Category,Description,FundingGoal,CurrentFund,DateCreated, Deadline,Users")] OptionProject project)
        //public async Task<IActionResult> Create([Bind("Title", "Description")] OptionProject project)
        {
            var checkUser = await _userService.CheckLoggedInUserAsync();

            if(checkUser.Data.UserId == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                await _projectService.CreateProjectAsync(new OptionProject
                {
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    Category = project.Category,
                    Description = project.Description,
                    FundingPackages = project.FundingPackages,
                    Images = new List<ImagePath> { },
                    Videos = new List<VideoPath> { },
                    StatusUpdates = project.StatusUpdates,
                    FundingGoal = project.FundingGoal,
                    CurrentFund = project.CurrentFund,
                    DateCreated = project.DateCreated,
                    Deadline = project.Deadline,
                    UserId = checkUser.Data.UserId
                });
                    var ProjectFromDb = await _projectService.GetProjectByIdAsync(project.ProjectId);
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                    foreach (var item in files)
                    {
                        var uploads = Path.Combine(webRootPath, "images");
                        var extension = Path.GetExtension(item.FileName);
                        var dynamicFileName = Guid.NewGuid().ToString() + "_" + project.ProjectId + extension;

                        using (var filesStream = new FileStream(Path.Combine(uploads, dynamicFileName), FileMode.Create))
                        {
                            item.CopyTo(filesStream);
                        }
                        project.Images.Add(new ImagePath { Image = dynamicFileName });
                    }
                    }
            }
            
            return RedirectToAction("Create","FundingPackage");
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

            return View("Index",projectsResult.Data);
        }

        public async Task<ActionResult> SearchBySearchBar([Bind("search")] string search)
        {

            var projectsResult = await _projectService.GetProjectsBySearch(search);

            if (projectsResult.Error != null)
            {
                return NotFound();
            }

            return View("Index", projectsResult.Data);
        }

        public async Task<ActionResult> MyProject(int? id)
        {
            ProjectDto projectDto = new ProjectDto();

            return NotFound();
            //var projectsResult = await _projectService.GetProjectsBySearch(search);

            //if (projectsResult.Error != null)
            //{
            //    return NotFound();
            //}

            //return View("Index", projectsResult.Data);
        }

    }

}
