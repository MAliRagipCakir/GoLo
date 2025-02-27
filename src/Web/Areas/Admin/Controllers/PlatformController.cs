﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.Areas.Admin.Models;
using Web.Interfaces;
using Web.Managers;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class PlatformController : Controller
    {

        private readonly IPlatformService _platformService;
        private readonly IPlatformViewModelService _platformViewModelService;

        public PlatformController(IPlatformService platformService, IPlatformViewModelService platformViewModelService)
        {
            _platformService = platformService;
            _platformViewModelService = platformViewModelService;
        }

        // GET: Admin/Platforms
        public async Task<IActionResult> Index()
        {
            return View(await _platformService.GetAllPlatformsAsync());
        }

        // GET: Admin/Platforms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Platforms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlatformName,LogoImage")] PlatformViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _platformViewModelService.CreatePlatformFromViewModelAsync(vm);
                }
                catch (ArgumentException ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(vm);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Platforms/Edit/5
        public async Task<IActionResult> Edit(int platformId)
        {
            Platform platform;
            PlatformEditViewModel vm;
            try
            {
                platform = await _platformService.GetPlatformByIdAsync(platformId);
                vm = await _platformViewModelService.GetPlatformEditViewModelAsync(platform);
            }
            catch (ArgumentException ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // POST: Admin/Platforms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlatformEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _platformViewModelService.UpdatePlatformFromViewModelAsync(vm);
                }
                catch (ArgumentException ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(vm);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // POST: Admin/Platforms/Delete/5
        public async Task<IActionResult> Delete(int platformId)
        {
            try
            {
                await _platformViewModelService.DeletePlatformThenPictureAsync(platformId);
            }
            catch (ArgumentException ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
