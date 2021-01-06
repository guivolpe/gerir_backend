using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Gerir.Api.Dominios;

namespace Senai.Gerir.Api.Interfaces
{
    public interface ITarefaRepositorio
    {
        Tarefa Cadastrar(Tarefa tarefa);
        List<Tarefa> ListarTodos(Guid IdUsuario);
        Tarefa AlteraStatus(Guid id);
        void Remover(Guid id);
        Tarefa Editar(Tarefa tarefa);
        Tarefa BuscarPorId(Guid id);
    }
}
