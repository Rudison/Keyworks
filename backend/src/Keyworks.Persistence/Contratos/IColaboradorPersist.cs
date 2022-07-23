using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface IColaboradorPersist
    {
        Task<Colaborador[]> GetAllColaboradoresByNomeAsync(string nome);
        Task<Colaborador[]> GetAllColaboradoresAsync();
        Task<Colaborador> GetColaboradorByIdAsync(int id);
    }
}