using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Domain;

namespace Keyworks.Persistence.Contratos
{
    public interface ITitulosPersist
    {
        Task<Titulo[]> GetAllTitulosByDescricaoAsync(string descricao);
        Task<Titulo[]> GetAllTitulosAsync();
        Task<Titulo> GetSTituloByIdAsync(int id);
    }
}