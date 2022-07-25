using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class StatusCardService : IStatusCardService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IStatusCardPersist _statusCardPersist;

        public StatusCardService(IGeralPersist geralPersist, IStatusCardPersist statusCardPersist)
        {
            _geralPersist = geralPersist;
            _statusCardPersist = statusCardPersist;
        }
        public async Task<StatusCard> AddStatusCard(StatusCard model)
        {
            try
            {
                _geralPersist.Add<StatusCard>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _statusCardPersist.GetStatusCardByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Status: " + ex.Message);
            }
        }

        public async Task<StatusCard> UpdateStatusCard(int id, StatusCard model)
        {
            try
            {
                var statusCard = await _statusCardPersist.GetStatusCardByIdAsync(id);

                if (statusCard == null) return null;

                model.Id = statusCard.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _statusCardPersist.GetStatusCardByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Status: " + ex.Message);
            }
        }
        public async Task<bool> DeleteStatusCard(int id)
        {
            try
            {
                var statusCard = await _statusCardPersist.GetStatusCardByIdAsync(id);

                if (statusCard == null) throw new Exception("Status nao encontrado para exclusao");

                _geralPersist.Delete<StatusCard>(statusCard);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Status: " + ex.Message);
            }
        }


        public async Task<StatusCard[]> GetAllStatusCardAsync()
        {
            try
            {
                var statusCards = await _statusCardPersist.GetAllStatusCardAsync();
                if (statusCards == null) return null;

                return statusCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusCard[]> GetAllStatusCardByDescricaoAsync(string descricao)
        {
            try
            {
                var statusCards = await _statusCardPersist.GetAllStatusCardByDescricaoAsync(descricao);
                if (statusCards == null) return null;

                return statusCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusCard> GetStatusCardByIdAsync(int id)
        {
            try
            {
                var statusCard = await _statusCardPersist.GetStatusCardByIdAsync(id);
                if (statusCard == null) return null;

                return statusCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}