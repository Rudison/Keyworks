using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface ISituacaoCardService
    {
        Task<SituacaoCard> AddSituacaoCard(SituacaoCard model);
        Task<SituacaoCard> UpdateSituacaoCard(int id, SituacaoCard model);
        Task<bool> DeleteSituacaoCard(int id);
        Task<SituacaoCard[]> GetAllSituacoesByNomeAsync(string descricao);
        Task<SituacaoCard[]> GetAllSituacoesAsync();
        Task<SituacaoCard> GetSituacaoByIdAsync(int id);
    }
}