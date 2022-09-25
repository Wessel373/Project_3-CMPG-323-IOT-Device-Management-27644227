﻿using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repositories
{
    public class CategoryRpository : GennericRepository<Category>, ICategoryRepository
    {
        public CategoryRpository(WebApp_CMPG323_27644227_Context _context) : base(_context)
        { 
        }

        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
        }

        
    }
}
