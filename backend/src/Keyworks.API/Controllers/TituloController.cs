using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keyworks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TituloController : Controller
    {
        private readonly ITituloService _tituloService;

        public TituloController(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tituloService = await _tituloService.GetAllTitulosAsync();
                if (tituloService == null) return NotFound("Nenhum Titulo encontrado");

                return Ok(tituloService);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar titulos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var titulo = await _tituloService.GetSTituloByIdAsync(id);
                if (titulo == null) return NotFound("Nenhum titulo encontrado");

                return Ok(titulo);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar titulo. Erro: {ex.Message}");
            }
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> GetByNome(string descricao)
        {
            try
            {
                var titulo = await _tituloService.GetAllTitulosByDescricaoAsync(descricao);
                if (titulo == null) return NotFound("Nenhum titulo encontrado");

                return Ok(titulo);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar titulo. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Titulo model)
        {
            try
            {
                var titulo = await _tituloService.AddTitulo(model);

                if (titulo == null) return BadRequest("Erro ao tentar adicionar novo titulo");

                return Ok(titulo);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar titulo. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Titulo model)
        {
            try
            {
                var titulo = await _tituloService.UpdateTitulo(id, model);

                if (titulo == null) return BadRequest("Erro ao tentar alterar titulo");

                return Ok(titulo);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar alterar titulo. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _tituloService.DeleteTitulo(id) ? Ok("Deletado") : BadRequest("Titulo nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir titulo. Erro: {ex.Message}");
            }
        }
    }
}