using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq;

namespace DeviceManagement_WebApp.Repositories
{
    public class ZoneRepository : GennericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(WebApp_CMPG323_27644227_Context _context) : base(_context)
        {
        }
        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(zone => zone.DateCreated).FirstOrDefault();
        }
    }
}
