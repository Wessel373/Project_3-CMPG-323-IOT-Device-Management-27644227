using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();

        void UpdateCategory(Category newCategory, Category oldCategory);

        bool CategoryExists(Guid id);
        
    }
}
