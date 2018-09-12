using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class AvaliacaoServico : IAvaliacaoServico
    {
        public int Cadastrar(Avaliacao obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                {
                    obj.DataCriacao = DateTime.UtcNow;
                    obj.DataEdicao = DateTime.UtcNow;
                    return new AvaliacaoRep().Add(obj);
                }
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetAllAsync(string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetAll();
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByAvaliado(int idAvaliado, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByAvaliado(idAvaliado);
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByAvaliador(int idAvaliador, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByAvaliadorAsync(idAvaliador);
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByCodigoExterno(int idOportunidade, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByCodigoExterno(idOportunidade);
                else
                    throw new Exception("Token inválido!");

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByOportunidade(int idOportunidade, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByOportunidade(idOportunidade);
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }
    }
}
