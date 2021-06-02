using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5;
using FundRaiser_Team5.Options;

namespace FundRaiserMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectInterface _projectService;

        public ProjectController(IProjectInterface projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _projectService.GetProjectsAsync());
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
        public async Task<IActionResult> Create([Bind("ProjectId,Title,Category,Description,FundingPackages,Images,Videos,StatusUpdates,FundingGoal,CurrentFund,DateCreated, Deadline,Users")] Project project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateProjectAsync(new OptionProject
                {
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    Category = project.Category,
                    Description = project.Description,
                    FundingPackages=project.FundingPackages,
                    Images=project.Images,
                    Videos=project.Videos,
                    StatusUpdates=project.StatusUpdates,
                    FundingGoal=project.FundingGoal,
                    CurrentFund=project.CurrentFund,
                    DateCreated=project.DateCreated,
                    Deadline=project.Deadline,
                    Users=project.Users

                });

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectService.DeleteProjectByIdAsync(id);

            return RedirectToAction(nameof(Index));

        }
    
    }
}
