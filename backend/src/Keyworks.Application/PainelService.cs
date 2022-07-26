using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class PainelService : IPainelService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPainelPersist _painelPersist;

        public PainelService(IGeralPersist geralPersist, IPainelPersist painelPersist)
        {
            _geralPersist = geralPersist;
            _painelPersist = painelPersist;
        }
        public async Task<Painel> AddPainel(Painel model)
        {
            try
            {
                _geralPersist.Add<Painel>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _painelPersist.GetPainelByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Painel: " + ex.Message);
            }
        }
        public async Task<Painel> UpdatePainel(int id, Painel model)
        {
            try
            {
                var painelCard = await _painelPersist.GetPainelByIdAsync(id);

                if (painelCard == null) return null;

                model.Id = painelCard.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _painelPersist.GetPainelByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Painel: " + ex.Message);
            }
        }

        public async Task<bool> DeletePainel(int id)
        {
            try
            {
                var painel = await _painelPersist.GetPainelByIdAsync(id);

                if (painel == null) throw new Exception("Painel nao encontrado para exclusao");

                _geralPersist.Delete<Painel>(painel);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Painel: " + ex.Message);
            }
        }

        public async Task<Painel[]> GetAllPaineisBySituacaoAsync(int situacaoId)
        {
            try
            {
                var painel = await _painelPersist.GetAllPaineisBySituacaoAsync(situacaoId);
                if (painel == null) return null;

                return painel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<dynamic> GetAllPainelAsync()
        {
            try
            {
                var painel = await _painelPersist.GetAllPaineisAsync();
                if (painel == null) return null;

                return painel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Painel> GetPainelByIdAsync(int id)
        {
            try
            {
                var painel = await _painelPersist.GetPainelByIdAsync(id);
                if (painel == null) return null;

                return painel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}