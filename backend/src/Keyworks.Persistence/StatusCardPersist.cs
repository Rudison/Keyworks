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
    public class StatusCardPersist : IStatusCardPersist
    {
        private readonly KeyworksContext _context;
        public StatusCardPersist(KeyworksContext context)
        {
            _context = context;
        }
        public async Task<StatusCard[]> GetAllStatusCardAsync()
        {
            IQueryable<StatusCard> query = _context.StatusCards;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<StatusCard[]> GetAllStatusCardByNomeAsync(string descricao)
        {
            IQueryable<StatusCard> query = _context.StatusCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<StatusCard> GetStatusCardByIdAsync(int id)
        {
            IQueryable<StatusCard> query = _context.StatusCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}