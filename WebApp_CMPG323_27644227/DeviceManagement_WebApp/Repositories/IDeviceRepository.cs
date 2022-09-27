using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repositories
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetMostRecentDevice();
        bool DeviceExists(Guid id);
        void UpdateDevice(Device newDevice, Device oldDevice);
        Device GetDeviceById(Guid id);
        async List<Device> GetAllDevices();
    }
    
    
}
