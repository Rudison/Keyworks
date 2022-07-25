using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface IPainelCardsPersist
    {
        Task<PainelCards[]> GetAllPainelCardsAsync();
        Task<PainelCards[]> GetAllPaineisCardBySituacaoAsync(int situacaoId);
        Task<PainelCards> GetPainelCardByIdAsync(int id);
    }
}