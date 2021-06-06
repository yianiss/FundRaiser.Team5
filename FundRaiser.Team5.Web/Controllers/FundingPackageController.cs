using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Web.Controllers
{
    public class FundingPackageController : Controller
    {
        private readonly IFundingPackageService _fundingPackageService;

        public FundingPackageController(IFundingPackageService fundingPackageService)
        {
            _fundingPackageService = fundingPackageService;
        }

        // GET : FundingPackage
        public async Task<IActionResult> Index()
        {

            var allFundingPackagesResult = await _fundingPackageService.ReadFundingPackageAsync();

            return View();
        }

        // GET: FundingPackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundingPackage = await _fundingPackageService.ReadFundingPackageAsync(id.Value);

            if (fundingPackage.Error != null || fundingPackage.Data == null)
            {
                return NotFound();
            }

            return View(fundingPackage.Data);
        }

        // GET: FundingPackage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FundingPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FundingPackageId,Project,Title,Description,MinPrice,NumberOfAvailablePackages")] OptionFundingPackage optionFundingPackage)
        {
            if (ModelState.IsValid)
            {
                await _fundingPackageService.CreateFundingPackageAsync(optionFundingPackage);

                return RedirectToAction(nameof(Index));
            }

            return View(optionFundingPackage);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allFundingPackageServiceResult = await _fundingPackageService.ReadFundingPackageAsync();

            return Ok(allFundingPackageServiceResult.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fundingPackageService.DecreaseFundingPackageAsync(id);

            return NoContent();
        }

    }
}
