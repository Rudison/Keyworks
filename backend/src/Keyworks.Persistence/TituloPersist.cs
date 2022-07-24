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
    public class TituloPersist : ITitulosPersist
    {
        private readonly KeyworksContext _context;
        public TituloPersist(KeyworksContext context)
        {
            _context = context;
        }
        public async Task<Titulo[]> GetAllTitulosAsync()
        {
            IQueryable<Titulo> query = _context.Titulos;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Titulo[]> GetAllTitulosByDescricaoAsync(string descricao)
        {
            IQueryable<Titulo> query = _context.Titulos;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Titulo> GetSTituloByIdAsync(int id)
        {
            IQueryable<Titulo> query = _context.Titulos;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}