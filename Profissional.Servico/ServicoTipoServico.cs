using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ServicoTipoServico : IServicoTipoSerico
    {
        public async Task<IList<ServicoTipo>> Get(string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return new ServicoTipoRep().GetList(st => st.IdCliente.Equals(idCliente));
                else
                    throw new Exception("Requisição inválida");
            }
            catch (Exception)
            {
                return new List<ServicoTipo>();
            }

        }

        public async Task<ServicoTipo> Get(int id, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await  new ServicoTipoRep().GetByIdAsync(id, idCliente);
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
