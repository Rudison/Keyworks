using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface IPainelCardService
    {
        Task<PainelCards> AddPainelCards(PainelCards model);
        Task<PainelCards> UpdatePainelCards(int id, PainelCards model);
        Task<bool> DeletePainelCards(int id);
        Task<PainelCards[]> GetAllPaineisCardBySituacaoAsync(int situacaoId);
        Task<PainelCards> GetPainelCardByIdAsync(int id);
    }
}