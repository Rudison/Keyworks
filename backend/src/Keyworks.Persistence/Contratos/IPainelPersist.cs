using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface IPainelPersist
    {
        Task<dynamic> GetAllPaineisAsync();
        Task<Painel[]> GetAllPaineisBySituacaoAsync(int situacaoId);
        Task<Painel> GetPainelByIdAsync(int id);
    }
}