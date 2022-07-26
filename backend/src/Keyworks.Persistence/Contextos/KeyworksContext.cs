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
        public DbSet<Painel> Paineis { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<SituacaoCard> SituacaoCards { get; set; }
        public DbSet<StatusCard> StatusCards { get; set; }
        public DbSet<Titulo> Titulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<PainelCards>()
            // .HasKey(p => new { p.CardId, p.PainelId });

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

            modelBuilder.Entity<Painel>()
           .HasData(
               new Painel
               {
                   Id = 1,
                   SituacaoId = 1,
                   PosicaoVertical = 0,
                   PosicaoHorizontal = 0
               },
               new Painel
               {
                   Id = 2,
                   SituacaoId = 2,
                   PosicaoVertical = 0,
                   PosicaoHorizontal = 1
               },
               new Painel
               {
                   Id = 3,
                   SituacaoId = 3,
                   PosicaoVertical = 0,
                   PosicaoHorizontal = 2
               },
                new Painel
                {
                    Id = 4,
                    SituacaoId = 4,
                    PosicaoVertical = 0,
                    PosicaoHorizontal = 3
                },
                new Painel
                {
                    Id = 5,
                    SituacaoId = 5,
                    PosicaoVertical = 0,
                    PosicaoHorizontal = 4
                }
           );
            modelBuilder.Entity<Card>()
            .HasData(
                new Card
                {
                    Id = 1,
                    TituloId = 1, //Desenvol/UX/Financeiro
                    SituacaoId = 1,//Aguardando/Em Andamento/
                    StatusId = 1,//Em dia/Atencao
                    NomeProjeto = "CRIAR MIGRATION",
                    DataPrevisao = new DateTime(2022, 07, 26),
                    Descricao = "Usar a branch master, fazer pull",
                    Previsto = new TimeSpan(0, 5, 10),
                    Saldo = new TimeSpan(0, 5, 5),
                    Equipe = "AS, PH, WC",
                },
                new Card
                {
                    Id = 2,
                    TituloId = 1,
                    SituacaoId = 1,
                    StatusId = 2,
                    NomeProjeto = "CRIAR SELECT DO RELATORIO",
                    DataPrevisao = new DateTime(2022, 07, 27),
                    Descricao = "Criar o select para o relatorio de vendas",
                    Previsto = new TimeSpan(0, 5, 10),
                    Saldo = new TimeSpan(0, 5, 5),
                    Equipe = "AS, PH, WC",
                },
                new Card
                {
                    Id = 3,
                    TituloId = 2,
                    SituacaoId = 2,
                    StatusId = 2,
                    NomeProjeto = "CRIAR NOVA HUD",
                    DataPrevisao = new DateTime(2022, 07, 28),
                    Descricao = "Criar nova hud para pontuacao",
                    Previsto = new TimeSpan(0, 5, 10),
                    Saldo = new TimeSpan(0, 5, 5),
                    Equipe = "AS, PH, WC",
                },
                 new Card
                 {
                     Id = 4,
                     TituloId = 3, //Desenvol/UX/Financeiro
                     SituacaoId = 4,//Aguardando/Em Andamento/
                     StatusId = 1,//Em dia/Atencao
                     NomeProjeto = "CRIAR PAINEL DE CONTROLE",
                     DataPrevisao = new DateTime(2022, 07, 29),
                     Descricao = "Desenvolver o painel conforme os padroes",
                     Previsto = new TimeSpan(0, 5, 10),
                     Saldo = new TimeSpan(0, 5, 5),
                     Equipe = "AS, PH, WC",
                 },
                 new Card
                 {
                     Id = 5,
                     TituloId = 2,
                     SituacaoId = 3,
                     StatusId = 2,
                     NomeProjeto = "CRIAR MIGRATION",
                     DataPrevisao = new DateTime(2022, 07, 30),
                     Descricao = "Usar a branch master, fazer pull",
                     Previsto = new TimeSpan(0, 5, 10),
                     Saldo = new TimeSpan(0, 5, 5),
                     Equipe = "AS, PH, WC",
                 },
                 new Card
                 {
                     Id = 6,
                     TituloId = 3,
                     SituacaoId = 2,
                     StatusId = 3,
                     NomeProjeto = "CRIAR MIGRATION",
                     DataPrevisao = new DateTime(2022, 07, 30),
                     Descricao = "Usar a branch master, fazer pull",
                     Previsto = new TimeSpan(0, 5, 10),
                     Saldo = new TimeSpan(0, 5, 5),
                     Equipe = "AS, PH, WC",
                 },
                  new Card
                  {
                      Id = 7,
                      TituloId = 3,
                      SituacaoId = 2,
                      StatusId = 2,
                      NomeProjeto = "CRIAR MIGRATION",
                      DataPrevisao = new DateTime(2022, 07, 30),
                      Descricao = "Usar a branch master, fazer pull",
                      Previsto = new TimeSpan(0, 5, 10),
                      Saldo = new TimeSpan(0, 5, 5),
                      Equipe = "AS, PH, WC",
                  },
                 new Card
                 {
                     Id = 8,
                     TituloId = 3,
                     SituacaoId = 3,
                     StatusId = 1,
                     NomeProjeto = "CRIAR MIGRATION",
                     DataPrevisao = new DateTime(2022, 07, 30),
                     Descricao = "Usar a branch master, fazer pull",
                     Previsto = new TimeSpan(0, 5, 10),
                     Saldo = new TimeSpan(0, 5, 5),
                     Equipe = "AS, PH, WC",
                 },
                 new Card
                 {
                     Id = 9,
                     TituloId = 3,
                     SituacaoId = 3,
                     StatusId = 3,
                     NomeProjeto = "CRIAR MIGRATION",
                     DataPrevisao = new DateTime(2022, 07, 30),
                     Descricao = "Usar a branch master, fazer pull",
                     Previsto = new TimeSpan(0, 5, 10),
                     Saldo = new TimeSpan(0, 5, 5),
                     Equipe = "AS, PH, WC",
                 }
            );

            modelBuilder.Entity<PainelCards>()
       .HasData(
           new PainelCards
           {
               Id = 1,
               CardId = 1,
               PainelId = 1
           },
           new PainelCards
           {
               Id = 2,
               CardId = 2,
               PainelId = 1
           },
           new PainelCards
           {
               Id = 3,
               CardId = 3,
               PainelId = 2
           },
            new PainelCards
            {
                Id = 4,
                CardId = 4,
                PainelId = 4
            },
            new PainelCards
            {
                Id = 5,
                CardId = 5,
                PainelId = 3
            },
            new PainelCards
            {
                Id = 6,
                CardId = 6,
                PainelId = 4
            },
            new PainelCards
            {
                Id = 7,
                CardId = 7,
                PainelId = 4
            },
            new PainelCards
            {
                Id = 8,
                CardId = 8,
                PainelId = 4
            },
            new PainelCards
            {
                Id = 9,
                CardId = 9,
                PainelId = 5
            }
       );
        }
    }
}