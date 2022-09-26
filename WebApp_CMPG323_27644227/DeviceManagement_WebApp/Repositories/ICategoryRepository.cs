﻿using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();

        void UpdateCategory(Category newcategory, Category oldcategory);
    }
}
