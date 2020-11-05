using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        TEntity ObterPorId(int id);
        IQueryable<TEntity> ObterTodos();
        void Alterar(TEntity obj);
        void Remover(Guid id);
        void Remover(int id);
        void Salvar();
    }
}
