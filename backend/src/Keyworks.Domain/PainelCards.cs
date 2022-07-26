using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyworks.Domain
{
    public class PainelCards
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int PainelId { get; set; }
        public Painel Painel { get; set; }
    }
}