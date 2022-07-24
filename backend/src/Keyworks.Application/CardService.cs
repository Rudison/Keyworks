using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;

namespace Keyworks.Application
{
    public class CardService : ICardService
    {
        public Task<Card> AddCard(Card model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCard(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Card> UpdateCard(int id, Card model)
        {
            throw new NotImplementedException();
        }

        public Task<Card[]> GetAllCardsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Card[]> GetAllCardsByStatusAsync(int statusId)
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetCardByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


    }
}