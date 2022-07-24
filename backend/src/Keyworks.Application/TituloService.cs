using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class TituloService : ITituloService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ITitulosPersist _titulosPersist;

        public TituloService(IGeralPersist geralPersist, ITitulosPersist titulosPersist)
        {
            _geralPersist = geralPersist;
            _titulosPersist = titulosPersist;
        }
        public async Task<Titulo> AddTitulo(Titulo model)
        {
            try
            {
                _geralPersist.Add<Titulo>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _titulosPersist.GetSTituloByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Titulo: " + ex.Message);
            }
        }
        public async Task<Titulo> UpdateTitulo(int id, Titulo model)
        {
            try
            {
                var titulo = await _titulosPersist.GetSTituloByIdAsync(id);

                if (titulo == null) return null;

                model.Id = titulo.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _titulosPersist.GetSTituloByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Titulo: " + ex.Message);
            }
        }
        public async Task<bool> DeleteTitulo(int id)
        {
            try
            {
                var titulo = await _titulosPersist.GetSTituloByIdAsync(id);

                if (titulo == null) throw new Exception("Titulo nao encontrado para exclusao");

                _geralPersist.Delete<Titulo>(titulo);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Titulo: " + ex.Message);
            }
        }

        public async Task<Titulo[]> GetAllTitulosAsync()
        {
            try
            {
                var titulo = await _titulosPersist.GetAllTitulosAsync();
                if (titulo == null) return null;

                return titulo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Titulo[]> GetAllTitulosByDescricaoAsync(string descricao)
        {
            try
            {
                var titulo = await _titulosPersist.GetAllTitulosByDescricaoAsync(descricao);
                if (titulo == null) return null;

                return titulo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Titulo> GetSTituloByIdAsync(int id)
        {
            try
            {
                var titulo = await _titulosPersist.GetSTituloByIdAsync(id);
                if (titulo == null) return null;

                return titulo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}