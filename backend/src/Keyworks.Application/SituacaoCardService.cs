using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class SituacaoCardService : ISituacaoCardService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ISituacaoCardPersist _situacaoCardPersist;

        public SituacaoCardService(IGeralPersist geralPersist, ISituacaoCardPersist situacaoCardPersist)
        {
            _geralPersist = geralPersist;
            _situacaoCardPersist = situacaoCardPersist;
        }
        public async Task<SituacaoCard> AddSituacaoCard(SituacaoCard model)
        {
            try
            {
                _geralPersist.Add<SituacaoCard>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _situacaoCardPersist.GetSituacaoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Situacao: " + ex.Message);
            }
        }

        public async Task<SituacaoCard> UpdateSituacaoCard(int id, SituacaoCard model)
        {
            try
            {
                var situacaoCard = await _situacaoCardPersist.GetSituacaoByIdAsync(id);

                if (situacaoCard == null) return null;

                model.Id = situacaoCard.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _situacaoCardPersist.GetSituacaoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Situacao: " + ex.Message);
            }
        }

        public async Task<bool> DeleteSituacaoCard(int id)
        {
            try
            {
                var situacaoCard = await _situacaoCardPersist.GetSituacaoByIdAsync(id);

                if (situacaoCard == null) throw new Exception("Situacao nao encontrada para exclusao");

                _geralPersist.Delete<SituacaoCard>(situacaoCard);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Situacao: " + ex.Message);
            }
        }

        public async Task<SituacaoCard[]> GetAllSituacoesAsync()
        {
            try
            {
                var situacaoCards = await _situacaoCardPersist.GetAllSituacoesAsync();
                if (situacaoCards == null) return null;

                return situacaoCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SituacaoCard[]> GetAllSituacoesByDescricaoAsync(string descricao)
        {
            try
            {
                var situacaoCards = await _situacaoCardPersist.GetAllSituacoesByDescricaoAsync(descricao);
                if (situacaoCards == null) return null;

                return situacaoCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SituacaoCard> GetSituacaoByIdAsync(int id)
        {
            try
            {
                var situacaoCard = await _situacaoCardPersist.GetSituacaoByIdAsync(id);
                if (situacaoCard == null) return null;

                return situacaoCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}