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
    public class PainelPersist : IPainelPersist
    {
        private readonly KeyworksContext _context;
        public PainelPersist(KeyworksContext context)
        {
            _context = context;
        }
        public async Task<dynamic> GetAllPaineisAsync()
        {
            var query = (from a in _context.Paineis
                         join b in _context.SituacaoCards on a.SituacaoId equals b.Id
                         select new
                         {
                             Id = a.Id,
                             Descricao = b.Descricao,
                             SituacaoId = b.Id,
                             PosicaoVertical = a.PosicaoVertical,
                             PosicaoHorizontal = a.PosicaoHorizontal
                         }).ToArrayAsync();

            return await query;
        }

        public async Task<Painel[]> GetAllPaineisBySituacaoAsync(int situacaoId)
        {
            IQueryable<Painel> query = _context.Paineis.Where(p => p.SituacaoId == situacaoId);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Painel> GetPainelByIdAsync(int id)
        {
            IQueryable<Painel> query = _context.Paineis.Where(p => p.Id == id);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}