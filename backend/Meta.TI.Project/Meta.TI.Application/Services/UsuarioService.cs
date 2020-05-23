using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;

namespace Meta.TI.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioViewModel Criar(UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
