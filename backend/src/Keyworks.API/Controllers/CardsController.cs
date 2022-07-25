using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.API;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keyworks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var card = await _cardService.GetAllCardsAsync();
                if (card == null) return NotFound("Nenhum Card encontrado");

                return Ok(card);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar card. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var card = await _cardService.GetCardByIdAsync(id);
                if (card == null) return NotFound("Nenhuma card encontrado");

                return Ok(card);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar card. Erro: {ex.Message}");
            }
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetAllCardsByStatusAsync(int statusId)
        {
            try
            {
                var situacao = await _cardService.GetAllCardsByStatusAsync(statusId);
                if (situacao == null) return NotFound("Nenhum card encontrado");

                return Ok(situacao);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar card. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Card model)
        {
            try
            {
                var card = await _cardService.AddCard(model);

                if (card == null) return BadRequest("Erro ao tentar adicionar novo card");

                return Ok(card);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar card. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Card model)
        {
            try
            {
                var card = await _cardService.UpdateCard(id, model);

                if (card == null) return BadRequest("Erro ao tentar alterar card");

                return Ok(card);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar alterar card. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _cardService.DeleteCard(id) ? Ok("Deletado") : BadRequest("Card nao deletado");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir card. Erro: {ex.Message}");
            }
        }
    }
}
