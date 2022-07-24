using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;

namespace Keyworks.Application
{
    public class SituacaoCardService : ISituacaoCardService
    {
        public Task<SituacaoCard> AddSituacaoCard(SituacaoCard model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSituacaoCard(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SituacaoCard[]> GetAllSituacoesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SituacaoCard[]> GetAllSituacoesByNomeAsync(string descricao)
        {
            throw new NotImplementedException();
        }

        public Task<SituacaoCard> GetSituacaoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SituacaoCard> UpdateSituacaoCard(int id, SituacaoCard model)
        {
            throw new NotImplementedException();
        }
    }
}