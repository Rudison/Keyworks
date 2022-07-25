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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
            .HasData(
                new Colaborador
                {
                    Id = 1,
                    Nome = "Afonso",
                    Sobrenome = "Solano"
                },
                new Colaborador
                {
                    Id = 2,
                    Nome = "Pedro",
                    Sobrenome = "Henrique"
                },
                new Colaborador
                {
                    Id = 3,
                    Nome = "Wellington",
                    Sobrenome = "Oliveira"
                }
            );

            modelBuilder.Entity<Titulo>()
            .HasData(
                new Titulo
                {
                    Id = 1,
                    Descricao = "Desenvolvimento",
                },
                new Titulo
                {
                    Id = 2,
                    Descricao = "UX|UI",
                },
                new Titulo
                {
                    Id = 3,
                    Descricao = "Financeiro",
                }
            );

            modelBuilder.Entity<StatusCard>()
          .HasData(
              new StatusCard
              {
                  Id = 1,
                  Descricao = "Em Dia",
              },
              new StatusCard
              {
                  Id = 2,
                  Descricao = "Atenção",
              },
              new StatusCard
              {
                  Id = 3,
                  Descricao = "Em Atraso",
              }
          );

            modelBuilder.Entity<SituacaoCard>()
          .HasData(
              new SituacaoCard
              {
                  Id = 1,
                  Descricao = "Aguardando",
              },
              new SituacaoCard
              {
                  Id = 2,
                  Descricao = "Em Adamento",
              },
              new SituacaoCard
              {
                  Id = 3,
                  Descricao = "Pendência",
              },
               new SituacaoCard
               {
                   Id = 4,
                   Descricao = "Finalizado",
               },
               new SituacaoCard
               {
                   Id = 5,
                   Descricao = "Outros",
               }
          );

            modelBuilder.Entity<PainelCards>()
           .HasData(
               new PainelCards
               {
                   Id = 1,
                   SituacaoId = 1,
                   PosicaoVertical = 0,
                   PosicaoHorizontal = 0
               },
               new PainelCards
               {
                   Id = 2,
                   SituacaoId = 2,
                   PosicaoVertical = 0,
                   PosicaoHorizontal = 1
               },
               new PainelCards
               {
                   Id = 3,
                   SituacaoId = 3,
                   PosicaoVertical = 0,
                   PosicaoHorizontal = 2
               },
                new PainelCards
                {
                    Id = 4,
                    SituacaoId = 4,
                    PosicaoVertical = 0,
                    PosicaoHorizontal = 3
                },
                new PainelCards
                {
                    Id = 5,
                    SituacaoId = 4,
                    PosicaoVertical = 0,
                    PosicaoHorizontal = 4
                }
           );
        }
    }
}