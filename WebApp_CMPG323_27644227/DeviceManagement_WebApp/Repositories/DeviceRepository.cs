using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repositories
{
    public class DeviceRepository : GennericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(WebApp_CMPG323_27644227_Context _context) : base(_context)
        {
        }

        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }

        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
        }

        public void UpdateDevice(Device newDevice, Device oldDevice)
        {
            oldDevice.DeviceName = newDevice.DeviceName;
            oldDevice.Status = newDevice.Status;
            oldDevice.DateCreated = newDevice.DateCreated;
            oldDevice.DeviceId = newDevice.DeviceId;
            oldDevice.IsActive = newDevice.IsActive;
            oldDevice.CategoryId = newDevice.CategoryId;
            oldDevice.Category = newDevice.Category;
            oldDevice.Zone = newDevice.Zone;
            oldDevice.ZoneId = newDevice.ZoneId;

            _context.Entry(oldDevice).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public Device GetDevice(Guid id)
        {            
            return _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefault(m => m.DeviceId == (Guid)id);
        }

        public List<Device> GetAllDevices()
        {            
            return _context.Device.Include(d => d.Category).Include(d => d.Zone).ToList();
        }
    }
}
