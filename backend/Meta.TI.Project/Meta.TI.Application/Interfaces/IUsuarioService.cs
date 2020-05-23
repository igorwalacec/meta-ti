using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Application.ViewModels;

namespace Meta.TI.Application.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        UsuarioViewModel Criar(UsuarioViewModel usuario);
    }
}
