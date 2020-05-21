using Meta.TI.Domain.Interfaces;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MetaTiContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(MetaTiContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }        
        public virtual IQueryable<TEntity> ObterTodos()
        {
            return DbSet;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(ObterPorId(id));
        }

        public virtual void Alterar(TEntity obj)
        {
            DbSet.Update(obj);            
        }
        public virtual void Salvar()
        {
            Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
