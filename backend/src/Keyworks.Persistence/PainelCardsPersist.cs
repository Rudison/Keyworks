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
    public class PainelCardsPersist : IPainelCardsPersist
    {
        private readonly KeyworksContext _context;
        public PainelCardsPersist(KeyworksContext context)
        {
            _context = context;
        }

        public async Task<PainelCards[]> GetAllPaineisCardBySituacaoAsync(int situacaoId)
        {
            IQueryable<PainelCards> query = _context.PainelCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.SituacaoId == situacaoId);

            return await query.ToArrayAsync();
        }

        public async Task<PainelCards[]> GetAllPainelCardsAsync()
        {
            IQueryable<PainelCards> query = _context.PainelCards;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<PainelCards> GetPainelCardByIdAsync(int id)
        {
            IQueryable<PainelCards> query = _context.PainelCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}