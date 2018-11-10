using Profissional.Infra;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ServicoServico : IServicoServico
    {
        private ServicoRep Rep = new ServicoRep();

        public async Task<List<Dominio.Entidades.Servico>> Get(string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var t = (await new ServicoRep().GetAll()).Where(s => s.IdCliente.Equals(idCliente)).ToList();
                    return t;
                }
                else
                    throw new Exception("Requisição inválida");

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<Dominio.Entidades.Servico> GetById(int id, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new ServicoRep().GetByIdAsync(id, idCliente);
                else
                    throw new Exception("Requisição inválida");
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public  List<Dominio.Entidades.Servico> GetByProfissional(int idProfissional, string token, int idCliente)
        {
            try
            {
                if ( SeguracaServ.validaToken(token))
                    return Rep.GetByProfissional(idProfissional, idCliente);
                else
                    throw new Exception("Requisição inválida");

            }
            catch (Exception)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new ServicoRep().GetByServicoTipoId(idTipo, idCliente);
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
