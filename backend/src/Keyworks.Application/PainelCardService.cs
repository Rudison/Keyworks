using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keyworks.Application.Contratos;
using Keyworks.Domain;
using Keyworks.Persistence.Contratos;

namespace Keyworks.Application
{
    public class PainelCardService : IPainelCardService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPainelCardsPersist _painelCardsPersist;

        public PainelCardService(IGeralPersist geralPersist, IPainelCardsPersist painelCardsPersist)
        {
            _geralPersist = geralPersist;
            _painelCardsPersist = painelCardsPersist;
        }
        public async Task<PainelCards> AddPainelCards(PainelCards model)
        {
            try
            {
                _geralPersist.Add<PainelCards>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _painelCardsPersist.GetPainelCardByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Adicionar Titulo: " + ex.Message);
            }
        }
        public async Task<PainelCards> UpdatePainelCards(int id, PainelCards model)
        {
            try
            {
                var painelCard = await _painelCardsPersist.GetPainelCardByIdAsync(id);

                if (painelCard == null) return null;

                model.Id = painelCard.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _painelCardsPersist.GetPainelCardByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Ao Alterar Titulo: " + ex.Message);
            }
        }

        public async Task<bool> DeletePainelCards(int id)
        {
            try
            {
                var painelCard = await _painelCardsPersist.GetPainelCardByIdAsync(id);

                if (painelCard == null) throw new Exception("Painel Card nao encontrado para exclusao");

                _geralPersist.Delete<PainelCards>(painelCard);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception("Erro ao Excluir Painel: " + ex.Message);
            }
        }

        public async Task<PainelCards[]> GetAllPaineisCardBySituacaoAsync(int situacaoId)
        {
            try
            {
                var painelCards = await _painelCardsPersist.GetAllPaineisCardBySituacaoAsync(situacaoId);
                if (painelCards == null) return null;

                return painelCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PainelCards> GetPainelCardByIdAsync(int id)
        {
            try
            {
                var painelCard = await _painelCardsPersist.GetPainelCardByIdAsync(id);
                if (painelCard == null) return null;

                return painelCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PainelCards[]> GetAllPainelCardsAsync()
        {
            try
            {
                var painelCard = await _painelCardsPersist.GetAllPainelCardsAsync();
                if (painelCard == null) return null;

                return painelCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}