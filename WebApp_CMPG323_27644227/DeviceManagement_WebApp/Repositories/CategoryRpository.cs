﻿using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public void UpdateCategory(Category newCategory, Category oldCategory)
        {
            oldCategory.CategoryName = newCategory.CategoryName;
            oldCategory.CategoryDescription = newCategory.CategoryDescription;
            oldCategory.DateCreated = newCategory.DateCreated;
            oldCategory.CategoryId = newCategory.CategoryId;

            _context.Entry(oldCategory).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
