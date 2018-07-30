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

        public async Task<List<Dominio.Entidades.Servico>> Get()
        {
            try
            {
                return await new ServicoRep().GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<Dominio.Entidades.Servico> GetById(int id)
        {
            try
            {
                return await new ServicoRep().GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public List<Dominio.Entidades.Servico> GetByProfissional(int idProfissional)
        {
            return Rep.GetByProfissional(idProfissional);
        }

        public async Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo)
        {
            try
            {
                return await new ServicoRep().GetByServicoTipoId(idTipo);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }
    }
}
