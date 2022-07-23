using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IColaboradorPersist _colaboradorPersist;
        public ColaboradorService(IGeralPersist geralPersist, IColaboradorPersist colaboradorPersist)
        {
            _geralPersist = geralPersist;
            _colaboradorPersist = colaboradorPersist;
        }
        public async Task<Colaborador> AddColaborador(Colaborador model)
        {
            try
            {
                _geralPersist.Add<Colaborador>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _colaboradorPersist.GetColaboradorByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Colaborador: " + ex.Message);
            }
        }
        public async Task<Colaborador> UpdateColaborador(int id, Colaborador model)
        {
            try
            {
                var colaborador = await _colaboradorPersist.GetColaboradorByIdAsync(id);

                if (colaborador == null) return null;

                model.Id = colaborador.Id;

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _colaboradorPersist.GetColaboradorByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Colaborador: " + ex.Message);
            }
        }

        public async Task<bool> DeleteColaborador(int id)
        {
            try
            {
                var colaborador = await _colaboradorPersist.GetColaboradorByIdAsync(id);

                if (colaborador == null) throw new Exception("Colaborador nao encontrado para exclusao");

                _geralPersist.Delete<Colaborador>(colaborador);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Colaborador: " + ex.Message);
            }
        }

        public async Task<Colaborador[]> GetAllColaboradoresAsync()
        {
            try
            {
                var colaboradores = await _colaboradorPersist.GetAllColaboradoresAsync();
                if (colaboradores == null) return null;

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Colaborador[]> GetAllColaboradoresByNomeAsync(string nome)
        {
            try
            {
                var colaboradores = await _colaboradorPersist.GetAllColaboradoresByNomeAsync(nome);
                if (colaboradores == null) return null;

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Colaborador> GetColaboradorByIdAsync(int id)
        {
            try
            {
                var colaborador = await _colaboradorPersist.GetColaboradorByIdAsync(id);
                if (colaborador == null) return null;

                return colaborador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}