using Profissional.Infra;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ServicoServico : IServicoServico
    {
        private ServicoRep Rep = new ServicoRep();

        public async Task<List<Dominio.Entidades.Servico>> Get(string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new ServicoRep().GetAll();
                else
                    throw new Exception("Requisição inválida");

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<Dominio.Entidades.Servico> GetById(int id, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new ServicoRep().GetByIdAsync(id);
                else
                    throw new Exception("Requisição inválida");
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public  List<Dominio.Entidades.Servico> GetByProfissional(int idProfissional, string token)
        {
            try
            {
                if ( SeguracaServ.validaToken(token))
                    return Rep.GetByProfissional(idProfissional);
                else
                    throw new Exception("Requisição inválida");

            }
            catch (Exception)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new ServicoRep().GetByServicoTipoId(idTipo);
                else
                    throw new Exception("Requisição inválida");

            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }
    }
}
