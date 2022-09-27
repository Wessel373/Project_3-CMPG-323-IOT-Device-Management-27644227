using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Repositories
{
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        void UpdateZone(Zone newZone, Zone oldZone);
        bool ZoneExists(Guid id);
        
    }

    


}
