﻿using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Web.Controllers
{
    public class UserFundingPackageController : Controller
    {
        private readonly IUserFundingPackageService _userFundingPackageService;

        public UserFundingPackageController(IUserFundingPackageService UserFundingPackageService)
        {
            _userFundingPackageService = UserFundingPackageService;
        }

        // GET : UserFundingPackages
        public async Task<IActionResult> Index()
        {

            var allUserFundingPackagesResult = await _userFundingPackageService.ReadUserFundingPackageAsync();

            return View();
        }

        // GET: UserFundingPackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFundingPackage = await _userFundingPackageService.ReadUserFundingPackageAsync(id.Value);

            if (userFundingPackage.Error != null || userFundingPackage.Data == null)
            {
                return NotFound();
            }

            return View(userFundingPackage.Data);
        }

        // GET: UserFundingPackage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFundingPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OptionUserFundingPackageId,UserId,FundingPackageId,Price,IsActive")] OptionUserFundingPackage optionUserFundingPackage)
        {
            if (ModelState.IsValid)
            {
                await _userFundingPackageService.CreateUserFundingPackageAsync(optionUserFundingPackage);

                return RedirectToAction(nameof(Index));
            }

            return View(optionUserFundingPackage);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allUserFundingPackageServiceResult = await _userFundingPackageService.ReadUserFundingPackageAsync();

            return Ok(allUserFundingPackageServiceResult.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userFundingPackageService.DeleteUserFundingPackageAsync(id);

            return NoContent();
        }

    }
}