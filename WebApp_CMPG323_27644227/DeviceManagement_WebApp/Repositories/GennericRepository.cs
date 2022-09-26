using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Set<I>().Add(entity);
            _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<I> entities)
        {
            _context.Set<I>().AddRange(entities);
            _context.SaveChangesAsync();
        }

        public IEnumerable<I> Find(Expression<Func<I, bool>> expression)
        {
            return _context.Set<I>().Where(expression);
        }

        public IEnumerable<I> GetAll()
        {
            return _context.Set<I>().ToList();
        }

        public I GetById(Guid id)
        {
            return _context.Set<I>().Find(id);
        }

        public void Remove(I entity)
        {
            _context.Set<I>().Remove(entity);
            _context.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<I> entities)
        {
            _context.Set<I>().RemoveRange(entities);
            _context.SaveChangesAsync();
        }
    }
}
