using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Api.Controllers
{
    [Route("myapi/[controller]")]
    [ApiController]
    public class ApiProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ApiProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: myapi/ApiProject
        // [Route("myapi/get/[controller]")]            ????Ginete?
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionProject>>> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();

            return projects.Data; 
        }
        // POST myapi/ApiProject
        [HttpPost]
        public async Task<ActionResult<OptionProject>> PostProject(OptionProject optionProject)
        {
            await _projectService.CreateProjectAsync(optionProject);

            return CreatedAtAction("Get Project", new { id = optionProject.ProjectId }, optionProject);
        }

        // PUT myapi/ApiProject/5              // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, OptionProject optionProject)
        {
            if (id != optionProject.ProjectId)
            {
                return BadRequest();
            }

            await _projectService.EditProjectAsync(id,optionProject);

            return NoContent();

        }

        // DELETE myapi/ApiProject/5       // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var optionProject = await _projectService.DeleteProjectByIdAsync(id);

            if (optionProject.Error != null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
