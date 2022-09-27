using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repositories
{
    public class ZoneRepository : GennericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(WebApp_CMPG323_27644227_Context _context) : base(_context)
        {
        }
        public void UpdateZone(Zone newZone, Zone oldZone)
        {
            oldZone.ZoneName = newZone.ZoneName;
            oldZone.ZoneDescription = newZone.ZoneDescription;
            oldZone.DateCreated = newZone.DateCreated;
            oldZone.ZoneId = newZone.ZoneId;

            _context.Entry(oldZone).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

    }
}
