using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contextos
{
    public class KeyworksContext : DbContext
    {
        public KeyworksContext(DbContextOptions<KeyworksContext> options) : base(options) { }
        public DbSet<PainelCards> PainelCards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<SituacaoCard> SituacaoCards { get; set; }
        public DbSet<StatusCard> StatusCards { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
    }
}