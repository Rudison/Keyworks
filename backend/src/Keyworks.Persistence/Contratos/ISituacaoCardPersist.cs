using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface ISituacaoCardPersist
    {
        Task<SituacaoCard[]> GetAllSituacoesByDescricaoAsync(string descricao);
        Task<SituacaoCard[]> GetAllSituacoesAsync();
        Task<SituacaoCard> GetSituacaoByIdAsync(int id);
    }
}