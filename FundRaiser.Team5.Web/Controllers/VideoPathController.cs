using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiser.Team5.Web.Controllers
{
    public class VideoPathController : Controller
    {
        private readonly IVideoPathService _videoPathService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public VideoPathController(IVideoPathService videoPathService)
        {
            _videoPathService = videoPathService;
        }

        // GET: Projects/{id}/videos
        public async Task<IActionResult> Index()
        {
            // Read Session of User Session[CurrentUser]
            int userId = 0;
            var sessionUser = HttpContext.Session.GetString("CurrentUser");
            if (sessionUser != null)
            {
                userId = Int32.Parse(sessionUser);
            }
            var allVideosResult = await _videoPathService.GetVideoPathsAsync();
            allVideosResult.Data[0].SessionUser = userId;
            return View(allVideosResult.Data);
        }

        // GET: Projects/{id}/video/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoPath = await _videoPathService.GetVideoPathByIdAsync(id.Value);

            if (videoPath.Error != null || videoPath.Data == null)
            {
                return NotFound();
            }

            return View(videoPath.Data);
        }

        // GET: Projects/{id}/videos/upload
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/{id}/videos/upload
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path")] OptionVideoPath video)
        {
            if (ModelState.IsValid)
            {
                await _videoPathService.CreateVideoPathAsync(video);

                return RedirectToAction(nameof(Index));
            }

            return View(video);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allVideoPathsResult = await _videoPathService.GetVideoPathsAsync();

            return Ok(allVideoPathsResult.Data);
        }

        // GET: projects/{id}/videos/{id}/delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoPath = await _videoPathService.GetVideoPathByIdAsync(id.Value);

            if (videoPath.Error != null || videoPath.Data == null)
            {
                return NotFound();
            }

            return View(videoPath.Data);
        }

        // POST: projects/{id}/videos/{id}/delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _videoPathService.DeleteVideoPathByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
