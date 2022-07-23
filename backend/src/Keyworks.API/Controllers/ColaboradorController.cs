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
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var colaboradores = await _colaboradorService.GetAllColaboradoresAsync();
                if (colaboradores == null) return NotFound("Nenhum Colaborador encontrado");

                return Ok(colaboradores);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar colaboradores. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var colaborador = await _colaboradorService.GetColaboradorByIdAsync(id);
                if (colaborador == null) return NotFound("Nenhum colaborador encontrado");

                return Ok(colaborador);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar colaborador. Erro: {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var colaborador = await _colaboradorService.GetAllColaboradoresByNomeAsync(nome);
                if (colaborador == null) return NotFound("Nenhum colaborador encontrado");

                return Ok(colaborador);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar colaborador. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Colaborador model)
        {
            try
            {
                var colaborador = await _colaboradorService.AddColaborador(model);

                if (colaborador == null) return BadRequest("Erro ao tentar adicionar novo colaborador");

                return Ok(colaborador);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar colaborador. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Colaborador model)
        {
            try
            {
                var colaborador = await _colaboradorService.UpdateColaborador(id, model);

                if (colaborador == null) return BadRequest("Erro ao tentar alterar colaborador");

                return Ok(colaborador);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar alterar colaborador. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _colaboradorService.DeleteColaborador(id) ? Ok("Deletado") : BadRequest("Colaborador nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir colaborador. Erro: {ex.Message}");
            }
        }
    }
}