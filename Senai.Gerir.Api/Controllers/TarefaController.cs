using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using Senai.Gerir.Api.Repositorios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController()
        {
            _tarefaRepositorio = new TarefaRepositorio();
        }



        [Authorize]
        [HttpGet("buscarporid/{id}")]
        public IActionResult BuscarPorID(Guid id) //buscarPorId
        {
            try
            {
                _tarefaRepositorio.BuscarPorId(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Tarefa tarefa) //Cadastar
        {
            try
            {
                _tarefaRepositorio.Cadastrar(tarefa);

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Editar(Tarefa tarefa) //Alterar

        {
            try
            {
                _tarefaRepositorio.Editar(tarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Excluir(Guid id) //Deletar

        {
            try
            {
                _tarefaRepositorio.Remover(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos() //Listar Todos
        {
            try
            {
                //Pega as informações da claims referente à tarefa
                var claimsTarefa = HttpContext.User.Claims;
                //Pega o id da tarefa na Claim Jti
                var tarefaid = claimsTarefa.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
                //pega as informações das tarefas
                var tarefa = _tarefaRepositorio.BuscarPorId(new Guid(tarefaid.Value));
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("status/{id}")]
        public IActionResult AlteraStatus(Guid id) //Alterar Status

        {
            try
            {
                
               var tarefa = _tarefaRepositorio.AlteraStatus(id);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






    }
}