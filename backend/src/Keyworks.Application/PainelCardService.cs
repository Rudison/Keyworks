using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;

namespace Keyworks.Application
{
    public class PainelCardService : IPainelCardService
    {
        public Task<PainelCards> AddPainelCards(PainelCards model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePainelCards(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PainelCards[]> GetAllPaineisCardBySituacaoAsync(int situacaoId)
        {
            throw new NotImplementedException();
        }

        public Task<PainelCards> GetPainelCardByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PainelCards> UpdatePainelCards(int id, PainelCards model)
        {
            throw new NotImplementedException();
        }
    }
}