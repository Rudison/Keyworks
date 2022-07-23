using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface IColaboradorService
    {
        Task<Colaborador> AddColaborador(Colaborador model);
        Task<Colaborador> UpdateColaborador(int id, Colaborador model);
        Task<bool> DeleteColaborador(int id);
        Task<Colaborador[]> GetAllColaboradoresByNomeAsync(string nome);
        Task<Colaborador[]> GetAllColaboradoresAsync();
        Task<Colaborador> GetColaboradorByIdAsync(int id);
    }
}