using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;

namespace Keyworks.Application
{
    public class StatusCardService : IStatusCardService
    {
        public Task<StatusCard> AddStatusCard(StatusCard model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStatusCard(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StatusCard[]> GetAllStatusCardAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StatusCard[]> GetAllStatusCardByNomeAsync(string descricao)
        {
            throw new NotImplementedException();
        }

        public Task<StatusCard> GetStatusCardByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StatusCard> UpdateStatusCard(int id, StatusCard model)
        {
            throw new NotImplementedException();
        }
    }
}