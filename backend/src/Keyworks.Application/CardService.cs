using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class CardService : ICardService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ICardPersist _cardPersist;

        public CardService(IGeralPersist geralPersist, ICardPersist cardPersist)
        {
            _geralPersist = geralPersist;
            _cardPersist = cardPersist;
        }
        public async Task<Card> AddCard(Card model)
        {
            try
            {
                _geralPersist.Add<Card>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _cardPersist.GetCardByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Card: " + ex.Message);
            }
        }

        public async Task<Card> UpdateCard(int id, Card model)
        {
            try
            {
                var card = await _cardPersist.GetCardByIdAsync(id);

                if (card == null) return null;

                model.Id = card.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _cardPersist.GetCardByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Card: " + ex.Message);
            }
        }
        public async Task<bool> DeleteCard(int id)
        {
            try
            {
                var card = await _cardPersist.GetCardByIdAsync(id);

                if (card == null) throw new Exception("Card nao encontrado para exclusao");

                _geralPersist.Delete<Card>(card);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Card: " + ex.Message);
            }
        }


        public async Task<Card[]> GetAllCardsAsync()
        {
            try
            {
                var cards = await _cardPersist.GetAllCardsAsync();
                if (cards == null) return null;

                return cards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Card[]> GetAllCardsByStatusAsync(int statusId)
        {
            try
            {
                var cards = await _cardPersist.GetAllCardsByStatusAsync(statusId);
                if (cards == null) return null;

                return cards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Card> GetCardByIdAsync(int id)
        {
            try
            {
                var card = await _cardPersist.GetCardByIdAsync(id);
                if (card == null) return null;

                return card;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}