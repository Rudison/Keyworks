using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyworks.Domain
{
    public class Painel
    {
        public int Id { get; set; }
        public int SituacaoId { get; set; }//Aguardando, Em Adamento, Pendencia, Finalizado, Outros
        public int PosicaoVertical { get; set; }//0 
        public int PosicaoHorizontal { get; set; }//0
        public IEnumerable<SituacaoCard> SituacaoCard { get; set; }
        public IEnumerable<PainelCards> PainelCards { get; set; }
    }
}