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
    public class SituacaoCardPersist : ISituacaoCardPersist
    {
        private readonly KeyworksContext _context;
        public SituacaoCardPersist(KeyworksContext context)
        {
            _context = context;
        }

        public async Task<SituacaoCard[]> GetAllSituacoesAsync()
        {
            IQueryable<SituacaoCard> query = _context.SituacaoCards;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<SituacaoCard[]> GetAllSituacoesByDescricaoAsync(string descricao)
        {
            IQueryable<SituacaoCard> query = _context.SituacaoCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<SituacaoCard> GetSituacaoByIdAsync(int id)
        {
            IQueryable<SituacaoCard> query = _context.SituacaoCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}