using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Application.Contratos
{
    public interface ITituloService
    {
        Task<Titulo> AddTitulo(Titulo model);
        Task<Titulo> UpdateTitulo(int id, Titulo model);
        Task<bool> DeleteTitulo(int id);
        Task<Titulo[]> GetAllTitulosByDescricaoAsync(string descricao);
        Task<Titulo[]> GetAllTitulosAsync();
        Task<Titulo> GetSTituloByIdAsync(int id);
    }
}