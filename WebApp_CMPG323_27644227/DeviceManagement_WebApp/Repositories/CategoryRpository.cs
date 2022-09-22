using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repositories
{
    public class CategoryRpository
    {
        private readonly WebApp_CMPG323_27644227Context _context = new WebApp_CMPG323_27644227Context();

        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }
    }
}
