using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repositories
{
    public interface IGenericRepository<I>
    {
        I GetById(Guid id);
        IEnumerable<I> GetAll();

        IEnumerable<I> Find(Expression<Func<I,bool>> expression);

        void Add(I entity);

        void AddRange(IEnumerable<I> entities);
        void Remove(I entity);

        void RemoveRange(IEnumerable<I> entities);
    }
}