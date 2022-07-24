using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface ICardService
    {
        Task<Card> AddCard(Card model);
        Task<Card> UpdateCard(int id, Card model);
        Task<bool> DeleteCard(int id);
        Task<Card[]> GetAllCardsByStatusAsync(int statusId);
        Task<Card[]> GetAllCardsAsync();
        Task<Card> GetCardByIdAsync(int id);
    }
}