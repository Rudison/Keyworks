using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface IStatusCardPersist
    {
        Task<StatusCard[]> GetAllStatusCardByNomeAsync(string descricao);
        Task<StatusCard[]> GetAllStatusCardAsync();
        Task<StatusCard> GetStatusCardByIdAsync(int id);
    }
}