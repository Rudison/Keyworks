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
    public class StatusCardController : Controller
    {
        private readonly IStatusCardService _statusCardService;

        public StatusCardController(IStatusCardService statusCardService)
        {
            _statusCardService = statusCardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var statusCard = await _statusCardService.GetAllStatusCardAsync();
                if (statusCard == null) return NotFound("Nenhum Status encontrado");

                return Ok(statusCard);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar Status. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var statusCard = await _statusCardService.GetStatusCardByIdAsync(id);
                if (statusCard == null) return NotFound("Nenhum status encontrado");

                return Ok(statusCard);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar status. Erro: {ex.Message}");
            }
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> GetByNome(string descricao)
        {
            try
            {
                var titulo = await _statusCardService.GetAllStatusCardByDescricaoAsync(descricao);
                if (titulo == null) return NotFound("Nenhum status encontrado");

                return Ok(titulo);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar status. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(StatusCard model)
        {
            try
            {
                var titulo = await _statusCardService.AddStatusCard(model);

                if (titulo == null) return BadRequest("Erro ao tentar adicionar novo status");

                return Ok(titulo);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar status. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StatusCard model)
        {
            try
            {
                var status = await _statusCardService.UpdateStatusCard(id, model);

                if (status == null) return BadRequest("Erro ao tentar alterar status");

                return Ok(status);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar alterar status. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _statusCardService.DeleteStatusCard(id) ? Ok("Deletado") : BadRequest("Status nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir status. Erro: {ex.Message}");
            }
        }
    }
}