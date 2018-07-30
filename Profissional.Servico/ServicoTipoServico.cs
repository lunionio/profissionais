using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ServicoTipoServico : IServicoTipoSerico
    {
        public async Task<List<ServicoTipo>> Get()
        {
            try
            {
                return await new ServicoTipoRep().GetAll();
            }
            catch (Exception)
            {
                return new List<ServicoTipo>();
            }

        }

        public async Task<ServicoTipo> Get(int id)
        {
            try
            {
                return await  new ServicoTipoRep().GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }
    }
}
