using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ServicoServico : IServicoServico
    {
        public async Task<List<Dominio.Entidades.Servico>> Get()
        {
            try
            {
                return await new ServicoRep().GetAll();
            }
            catch (Exception ex)
            {
                return new List<Dominio.Entidades.Servico>();
            }
        }

        public Dominio.Entidades.Servico GetById(int id)
        {
            try
            {
                return new ServicoRep().GetById(id);
            }
            catch (Exception)
            {

                return new Dominio.Entidades.Servico();
            }
        }

        public async Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo)
        {
            try
            {
                return await new ServicoRep().GetByServicoTipoId(idTipo);
            }
            catch (Exception)
            {

                return new List<Dominio.Entidades.Servico>();
            }
        }
    }
}
