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
    public class SituacaoCardController : Controller
    {
        private readonly ISituacaoCardService _situacaoCardService;

        public SituacaoCardController(ISituacaoCardService situacaoCardService)
        {
            _situacaoCardService = situacaoCardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var situacao = await _situacaoCardService.GetAllSituacoesAsync();
                if (situacao == null) return NotFound("Nenhum Situacao encontrado");

                return Ok(situacao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar situacao. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var situacao = await _situacaoCardService.GetSituacaoByIdAsync(id);
                if (situacao == null) return NotFound("Nenhuma situação encontrada");

                return Ok(situacao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar situacao. Erro: {ex.Message}");
            }
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> GetByNome(string descricao)
        {
            try
            {
                var situacao = await _situacaoCardService.GetAllSituacoesByDescricaoAsync(descricao);
                if (situacao == null) return NotFound("Nenhum situacao encontrada");

                return Ok(situacao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar situacao. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(SituacaoCard model)
        {
            try
            {
                var situacao = await _situacaoCardService.AddSituacaoCard(model);

                if (situacao == null) return BadRequest("Erro ao tentar adicionar nova situacao");

                return Ok(situacao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar situacao. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SituacaoCard model)
        {
            try
            {
                var situacao = await _situacaoCardService.UpdateSituacaoCard(id, model);

                if (situacao == null) return BadRequest("Erro ao tentar alterar situacao");

                return Ok(situacao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar alterar situacao. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _situacaoCardService.DeleteSituacaoCard(id) ? Ok("Deletado") : BadRequest("Situacao nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir situacao. Erro: {ex.Message}");
            }
        }
    }
}