﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly WebApp_CMPG323_27644227_Context _context;

        private readonly IDeviceRepository _deviceRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IZoneRepository _zoneRepository;

        public DevicesController(IDeviceRepository deviceRepository, ICategoryRepository categoryRepository, IZoneRepository zoneRepository)
        {
            _deviceRepository = deviceRepository;
            _zoneRepository = zoneRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {            
            return View(_deviceRepository.GetAllDevices());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetDeviceById((Guid)id);
                
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _deviceRepository.Add(device);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var editDevice = _deviceRepository.GetById((Guid)id);
            if (id == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName", editDevice.CategoryId);
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName", editDevice.ZoneId);
            return View(editDevice);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            var editDevice = _deviceRepository.GetById((Guid)id);
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepository.UpdateDevice(device, editDevice);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_deviceRepository.DeviceExists(device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetDeviceById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = _deviceRepository.GetById(id);
            _deviceRepository.Remove(device);
           
            return RedirectToAction(nameof(Index));
        }

    }
}
