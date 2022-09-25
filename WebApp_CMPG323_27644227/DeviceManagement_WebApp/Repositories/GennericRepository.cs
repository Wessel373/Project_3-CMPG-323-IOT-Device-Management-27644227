using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repositories
{
    public class GennericRepository<I> : IGenericRepository<I> where I : class
    {
        protected readonly WebApp_CMPG323_27644227_Context _context;

        public GennericRepository(WebApp_CMPG323_27644227_Context context) 
        {
            _context = context;
        }
        public void Add(I entity)
        {
            _context.Add(entity);
            _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<I> entities)
        {
            _context.AddRange(entities);
            _context.SaveChangesAsync();
        }

        public IEnumerable<I> Find(Expression<Func<I, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<I> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public I GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(I entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<I> entities)
        {
            throw new NotImplementedException();
        }
    }
}
