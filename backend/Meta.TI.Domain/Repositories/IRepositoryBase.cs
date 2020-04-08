using System;
using System.Collections.Generic;

namespace Meta.TI.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetObject(Func<T, bool> expression);
        IEnumerable<T> GetList(Func<T, bool> expression);
    }
}