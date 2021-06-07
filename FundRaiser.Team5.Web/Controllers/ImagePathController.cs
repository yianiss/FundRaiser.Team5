using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiser.Team5.Web.Controllers
{
    public class ImagePathController : Controller
    {
        private readonly IImagePathService _imagePathService;

        public ImagePathController(IImagePathService imagePathService)
        {
            _imagePathService = imagePathService;
        }

        // GET: Projects/{id}/images
        public async Task<IActionResult> Index()
        {
            var allImagesResult = await _imagePathService.GetImagePathsAsync();

            return View(allImagesResult.Data);
        }

        // GET: Projects/{id}/images/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagePath = await _imagePathService.GetImagePathByIdAsync(id.Value);

            if (imagePath.Error != null || imagePath.Data == null)
            {
                return NotFound();
            }

            return View(imagePath.Data);
        }

        // GET: Projects/{id}/images/upload
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/{id}/images/upload
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path")] OptionImagePath image)
        {
            if (ModelState.IsValid)
            {
                await _imagePathService.CreateImagePathAsync(image);

                return RedirectToAction(nameof(Index));
            }

            return View(image);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allImagePathsResult = await _imagePathService.GetImagePathsAsync();

            return Ok(allImagePathsResult.Data);
        }

        // GET: projects/{id}/images/{id}/delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagePath = await _imagePathService.GetImagePathByIdAsync(id.Value);

            if (imagePath.Error != null || imagePath.Data == null)
            {
                return NotFound();
            }

            return View(imagePath.Data);
        }

        // POST: projects/{id}/images/{id}/delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _imagePathService.DeleteImagePathByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
