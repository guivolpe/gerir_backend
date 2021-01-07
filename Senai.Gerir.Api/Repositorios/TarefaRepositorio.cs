using Senai.Gerir.Api.Contextos;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gerir.Api.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly GerirContext _context;

        public TarefaRepositorio()
        {
            _context = new GerirContext();
        }

        public Tarefa AlterarStatus(Guid IdTarefa)
        {
            try
            {
                //Busca a tarefa pelo seu id
                var tarefa = BuscarPorId(IdTarefa);

                //Altera o valor do status conforme estiver no banco
                //Se estiver true o inverso é false
                //Se estiver false o inverso é true
                tarefa.Status = !tarefa.Status;

                _context.Tarefas.Update(tarefa);
                _context.SaveChanges();

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa BuscarPorId(Guid IdTarefa)
        {
            try
            {
                return _context.Tarefas.Find(IdTarefa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Cadastrar(Tarefa tarefa)
        {
            try
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Editar(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> Listar(Guid IdUsuario)
        {
            try
            {
                return _context.Tarefas.Where(
                            c => c.UsuarioId == IdUsuario
                            ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid IdTarefa)
        {
            throw new NotImplementedException();
        }
    }
}