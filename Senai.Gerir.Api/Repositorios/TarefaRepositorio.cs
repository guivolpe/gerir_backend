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
        //Declaro um objeto do tipo GerirContext que será
        //a representação do banco de dados
        private readonly GerirContext _context;

        public TarefaRepositorio()
        {
            //Cria uma instância de GerirContext
            _context = new GerirContext();
        }



        public Tarefa BuscarPorId(Guid id)
        {
            try
            {

                var tarefa = _context.Tarefas.Find(id);
                return tarefa;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Tarefa Cadastrar(Tarefa tarefa)
        {
            try
            {
                //adiciona uma tarefa ao DbSet Usuarios do contexto
                _context.Tarefas.Add(tarefa);
                //Salva as alterações do contexto
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
            try
            {
                //Busca tarefa no banco
                var tarefaexiste = BuscarPorId(tarefa.Id);
                //Verifica se tarefa existe
                if (tarefaexiste == null)
                    throw new Exception("Usuario não encontrado");

                //Altera os valores do usuário
                tarefaexiste.Titulo = tarefa.Titulo;
                tarefaexiste.Descricao = tarefa.Descricao;
                tarefaexiste.Categoria = tarefa.Categoria;
                tarefaexiste.DataEntrega = tarefa.DataEntrega;
                tarefaexiste.UsuarioId = tarefa.UsuarioId;


                _context.Tarefas.Update(tarefaexiste);

                //salva no BD
                _context.SaveChanges();

                return tarefaexiste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Tarefa> ListarTodos(Guid IdUsuario)
        {
            try
            {
                var listaDeTarefas = _context.Tarefas.Where(tarefa => tarefa.UsuarioId == IdUsuario);
                return (List<Tarefa>)listaDeTarefas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private object BuscarPorId(object id)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid Id)
        {
            try
            {
                var tarefa = BuscarPorId(Id);
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Tarefa AlteraStatus(Guid idtarefa)

        {
            try
            {
                //Busca tarefa no banco
                var tarefaexiste = BuscarPorId(idtarefa);
                //Verifica se tarefa existe
                if (tarefaexiste == null)
                    throw new Exception("Usuario não encontrado");

                //Altera os valores do usuário
                tarefaexiste.Status = !tarefaexiste.Status;

                _context.Tarefas.Update(tarefaexiste);

                //salva no BD
                _context.SaveChanges();

                return tarefaexiste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

