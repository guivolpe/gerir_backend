using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Gerir.Api.Dominios;

namespace Senai.Gerir.Api.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario Logar(string email, string senha);
        Usuario Editar(Usuario usuario);
        void Remover(Guid id);
        Usuario BuscarPorId(Guid id);
    }
}
