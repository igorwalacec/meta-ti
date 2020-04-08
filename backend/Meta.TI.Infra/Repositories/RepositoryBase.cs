using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Repositories;
using Meta.TI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly MetaTiContext _context;
        public RepositoryBase(MetaTiContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetList(Func<T, bool> expression)
        {
            IEnumerable<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            list = dbQuery.AsNoTracking().Where(expression).ToList<T>();

            return list;
        }

        public T GetObject(Func<T, bool> expression)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(expression);
        }
    }
}