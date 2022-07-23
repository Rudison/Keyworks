using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyworks.Domain
{
    public class Card
    {
        public int Id { get; set; }// Codigo
        public int TituloId { get; set; }//Desenvolvimento, Ux, financeiro
        public int StatusId { get; set; } //Em Dia, Atencao, Em Atraso
        public int SituacaoId { get; set; }//Aguardando, Em Adamento, Pendencia, Finalizado, Outros
        public string NomeProjeto { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Previsto { get; set; }
        public TimeSpan Saldo { get; set; }
        public string Equipe { get; set; }
        public StatusCard StatusCard { get; set; }
        public Titulo Titulo { get; set; }
        public SituacaoCard SituacaoCard { get; set; }
    }
}