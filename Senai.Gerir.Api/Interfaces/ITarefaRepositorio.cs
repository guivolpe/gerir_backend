using Senai.Gerir.Api.Dominios;
using System;
using System.Collections.Generic;

namespace Senai.Gerir.Api.Interfaces
{
    public interface ITarefaRepositorio
    {
        /// <summary>
        /// Cadastra uma nova tarefa
        /// </summary>
        /// <param name="tarefa">Recebe uma Tarefa</param>
        /// <returns>Retorna uma tarefa</returns>
        Tarefa Cadastrar(Tarefa tarefa);

        /// <summary>
        /// Lista as tarefas de um determinado usário
        /// </summary>
        /// <param name="IdUsuario">id do usuário</param>
        /// <returns>Retorna uma lista com as tarefas</returns>
        List<Tarefa> Listar(Guid IdUsuario);

        /// <summary>
        /// Altera o Status de uma tarefa
        /// </summary>
        /// <param name="IdTarefa">Id da tarefa</param>
        /// <returns>Retorna a tarefa alterada</returns>
        Tarefa AlterarStatus(Guid IdTarefa);

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        /// <param name="IdTarefa">Id da tarefa</param>
        void Remover(Guid IdTarefa);

        /// <summary>
        /// Edita uma nova tarefa
        /// </summary>
        /// <param name="tarefa">Tarefa a ser alterada</param>
        /// <returns>Retorna uma Tarefa</returns>
        Tarefa Editar(Tarefa tarefa);

        /// <summary>
        /// Busca uma tarefa pelo Id
        /// </summary>
        /// <param name="IdTarefa">Id da tarefa</param>
        /// <returns>Retorna a tarefa</returns>
        Tarefa BuscarPorId(Guid IdTarefa);
    }
}
