using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using Senai.Gerir.Api.Repositorios;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
        [HttpPost]
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Atribui o usuario a tarefa
                tarefa.UsuarioId = new System.Guid(usuarioid.Value);

                //Cadastra a tarefa
                _tarefaRepositorio.Cadastrar(tarefa);
                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                var tarefas = _tarefaRepositorio.Listar(
                                    new System.Guid(usuarioid.Value)
                              );

                return Ok(tarefas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        //api/tarefa/idTarefa
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefa = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefa == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        //api/tarefa/status/idTarefa
        [HttpPut("status/{id}")]
        public IActionResult AlterarStatus(Guid id)
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefa = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefa == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefa.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                _tarefaRepositorio.AlterarStatus(id);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Editar(Guid id, Tarefa tarefa)
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefaexiste = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefaexiste == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefaexiste.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                //Atribui o valor do Id da tarefa ao id recebido como parametro na url
                tarefa.Id = id;
                _tarefaRepositorio.Editar(tarefa);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                //Pega o valor do usuário que esta logado
                var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );

                //Busca uma tarefa pelo seu Id
                var tarefaexiste = _tarefaRepositorio.BuscarPorId(id);

                //Verifica se a tarefa existe
                if (tarefaexiste == null)
                    return NotFound();

                //Verifica se a tarefa é do usuário logado
                if (tarefaexiste.UsuarioId != new Guid(usuarioid.Value))
                    return Unauthorized("Usuário não tem permissão");

                _tarefaRepositorio.Remover(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
