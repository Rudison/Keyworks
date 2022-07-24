using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface ICardPersist
    {
        Task<Card[]> GetAllCardsByStatusAsync(int statusId);
        Task<Card[]> GetAllCardsAsync();
        Task<Card> GetCardByIdAsync(int id);
    }
}