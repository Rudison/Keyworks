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
    public class ColaboradorPersist : IColaboradorPersist
    {
        private readonly KeyworksContext _context;
        public ColaboradorPersist(KeyworksContext context)
        {
            _context = context;
        }
        public async Task<Colaborador[]> GetAllColaboradoresAsync()
        {
            IQueryable<Colaborador> query = _context.Colaboradores;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Colaborador[]> GetAllColaboradoresByNomeAsync(string nome)
        {
            IQueryable<Colaborador> query = _context.Colaboradores;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Colaborador> GetColaboradorByIdAsync(int id)
        {
            IQueryable<Colaborador> query = _context.Colaboradores;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}