using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface IPainelService
    {
        Task<Painel> AddPainel(Painel model);
        Task<Painel> UpdatePainel(int id, Painel model);
        Task<bool> DeletePainel(int id);
        Task<dynamic> GetAllPainelAsync();
        Task<Painel[]> GetAllPaineisBySituacaoAsync(int situacaoId);
        Task<Painel> GetPainelByIdAsync(int id);
    }
}