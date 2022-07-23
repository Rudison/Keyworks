using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyworks.Domain
{
    public class PainelCards
    {
        public int Id { get; set; }
        public int SituacaoId { get; set; }//Aguardando, Em Adamento, Pendencia, Finalizado, Outros
        public int CardId { get; set; }
        public int OrdemCard { get; set; }//0
        public int PosicaoVertical { get; set; }//0 
        public int PosicaoHorizontal { get; set; }//0
        public SituacaoCard SituacaoCard { get; set; }
        public Card Card { get; set; }
    }
}