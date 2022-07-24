using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;
using Keyworks.Persistence.Contextos;
using Keyworks.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Keyworks.Persistence
{
    public class CardPersist : ICardPersist
    {
        private readonly KeyworksContext _context;
        public CardPersist(KeyworksContext context)
        {
            _context = context;
        }

        public async Task<Card[]> GetAllCardsAsync()
        {
            IQueryable<Card> query = _context.Cards;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Card[]> GetAllCardsByStatusAsync(int statusId)
        {
            IQueryable<Card> query = _context.Cards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.StatusId == statusId);

            return await query.ToArrayAsync();
        }

        public async Task<Card> GetCardByIdAsync(int id)
        {
            IQueryable<Card> query = _context.Cards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}