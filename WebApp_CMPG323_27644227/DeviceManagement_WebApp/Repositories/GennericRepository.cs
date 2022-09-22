using DeviceManagement_WebApp.Data;
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
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
