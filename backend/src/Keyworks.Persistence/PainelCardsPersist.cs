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

        public async Task<PainelCards[]> GetAllPaineisCardByPainelAsync(int painelId)
        {
            IQueryable<PainelCards> query = _context.PainelCards.Include(p => p.Card).Include(p => p.Painel);

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.PainelId == painelId);

            return await query.ToArrayAsync();
        }

        public async Task<PainelCards[]> GetAllPainelCardsAsync()
        {
            IQueryable<PainelCards> query = _context.PainelCards.Include(p => p.Painel).Include(p => p.Card);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<dynamic> GetAllCompletePaineisAsync(int situacaoId)
        {
            var query = (from a in _context.PainelCards
                         join b in _context.Cards on a.CardId equals b.Id
                         join c in _context.Paineis on a.PainelId equals c.Id
                         join d in _context.Titulos on b.TituloId equals d.Id
                         join e in _context.StatusCards on b.StatusCardId equals e.Id
                         join f in _context.SituacaoCards on b.SituacaoCardId equals f.Id
                         select new
                         {
                             Id = a.Id,
                             PainelId = c.Id,
                             Titulo = d.Descricao,
                             Status = e.Descricao,
                             SituacaoCardId = f.Id,
                             Situacao = f.Descricao,
                             NomeProjeto = b.NomeProjeto,
                             DataPrevisao = b.DataPrevisao,
                             Descricao = b.Descricao,
                             Previsto = b.Previsto,
                             Saldo = b.Saldo,
                             Equipe = b.Equipe
                         }
                               ).Where(p => p.SituacaoCardId == situacaoId).ToArrayAsync();

            return await query;
        }

        public async Task<PainelCards> GetPainelCardByIdAsync(int id)
        {
            IQueryable<PainelCards> query = _context.PainelCards;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}