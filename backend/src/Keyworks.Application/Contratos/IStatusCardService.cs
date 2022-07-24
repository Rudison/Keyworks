using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface IStatusCardService
    {
        Task<StatusCard> AddStatusCard(StatusCard model);
        Task<StatusCard> UpdateStatusCard(int id, StatusCard model);
        Task<bool> DeleteStatusCard(int id);
        Task<StatusCard[]> GetAllStatusCardByNomeAsync(string descricao);
        Task<StatusCard[]> GetAllStatusCardAsync();
        Task<StatusCard> GetStatusCardByIdAsync(int id);
    }
}