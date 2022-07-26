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
        Task<PainelCards[]> GetAllPaineisCardByPainelAsync(int painelId);
        Task<PainelCards> GetPainelCardByIdAsync(int id);
        Task<dynamic> GetAllCompletePaineisAsync(int situacaoId);
    }
}