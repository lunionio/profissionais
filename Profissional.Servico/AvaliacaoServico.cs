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
        public  int Cadastrar(Avaliacao obj)
        {
            try
            {
                return new AvaliacaoRep().Add(obj);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetAllAsync()
        {
            try
            {
                return await new AvaliacaoRep().GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByAvaliado(int idAvaliado)
        {
            try
            {
                return await new AvaliacaoRep().GetByAvaliado(idAvaliado);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByAvaliador(int idAvaliador)
        {
            try
            {
                return await new AvaliacaoRep().GetByAvaliadorAsync(idAvaliador);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByCodigoExterno(int idOportunidade)
        {
            try
            {
                return await new AvaliacaoRep().GetByCodigoExterno(idOportunidade);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByOportunidade(int idOportunidade)
        {
            try
            {
                return await new AvaliacaoRep().GetByOportunidade(idOportunidade);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }
    }
}
