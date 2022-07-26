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
    [Route("api/[controller]")]
    public class PainelController : Controller
    {
        private readonly IPainelService _painelService;

        public PainelController(IPainelService painelService)
        {
            _painelService = painelService;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            try
            {
                var painel = await _painelService.GetAllPainelAsync();
                if (painel == null) return NotFound("Nenhum Painel encontrado");

                return Ok(painel);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar painel. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var painelCard = await _painelService.GetPainelByIdAsync(id);
                if (painelCard == null) return NotFound("Nenhum painel encontrado");

                return Ok(painelCard);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar painel. Erro: {ex.Message}");
            }
        }

        [HttpGet("situacao/{situacaoId}")]
        public async Task<IActionResult> GetByStiuacao(int situacaoId)
        {
            try
            {
                var painel = await _painelService.GetAllPaineisBySituacaoAsync(situacaoId);
                if (painel == null) return NotFound("Nenhum Painel Card encontrado");

                return Ok(painel);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar Painel. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Painel model)
        {
            try
            {
                var painel = await _painelService.AddPainel(model);

                if (painel == null) return BadRequest("Erro ao tentar adicionar novo painel");

                return Ok(painel);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar painel. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Painel model)
        {
            try
            {
                var painelCard = await _painelService.UpdatePainel(id, model);

                if (painelCard == null) return BadRequest("Erro ao tentar alterar painel");

                return Ok(painelCard);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar alterar painel. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _painelService.DeletePainel(id) ? Ok("Deletado") : BadRequest("Painel nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir painel. Erro: {ex.Message}");
            }
        }
    }
}