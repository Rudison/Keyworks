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
    public class PainelCard : Controller
    {
        private readonly IPainelCardService _painelCardService;

        public PainelCard(IPainelCardService painelCardService)
        {
            _painelCardService = painelCardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var painelCard = await _painelCardService.GetAllPainelCardsAsync();
                if (painelCard == null) return NotFound("Nenhum Painel Card encontrado");

                return Ok(painelCard);
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
                var painelCard = await _painelCardService.GetPainelCardByIdAsync(id);
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
        public async Task<IActionResult> GetByNome(int situacaoId)
        {
            try
            {
                var titulo = await _painelCardService.GetAllPaineisCardBySituacaoAsync(situacaoId);
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
        public async Task<IActionResult> Post(PainelCards model)
        {
            try
            {
                var painel = await _painelCardService.AddPainelCards(model);

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
        public async Task<IActionResult> Put(int id, PainelCards model)
        {
            try
            {
                var painelCard = await _painelCardService.UpdatePainelCards(id, model);

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
                return await _painelCardService.DeletePainelCards(id) ? Ok("Deletado") : BadRequest("Painel nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir painel. Erro: {ex.Message}");
            }
        }
    }
}