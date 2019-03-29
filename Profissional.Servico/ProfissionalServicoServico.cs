using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ProfissionalServicoServico : IProfissionalServicoServico
    {
        private ProfissionalServicoRep _Rep = new ProfissionalServicoRep();

        public void Alterar(ProfissionalServico obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                {
                    obj.DataEdicao = DateTime.UtcNow;
                    _Rep.Update(obj);
                }
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public ProfissionalServico Cadastrar(ProfissionalServico obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                {
                    if (obj.ID == 0)
                    {
                        obj.DataCriacao = DateTime.UtcNow;
                        obj.DataEdicao = DateTime.UtcNow;
                        obj.ID = _Rep.Add(obj);
                    }
                    else
                    {
                        obj.DataEdicao = DateTime.UtcNow;
                        _Rep.Update(obj);
                    }

                    return obj;
                }
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<IList<ProfissionalServico>> GetAll(string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                    return _Rep.GetList(ps => ps.IdCliente.Equals(idCliente));
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
                
            }
        }

        public void Remover(ProfissionalServico obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                    _Rep.Remove(obj);
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");

            }
        }

        Task<ProfissionalServico> IProfissionalServicoServico.Cadastrar(ProfissionalServico obj, string token)
        {
            throw new NotImplementedException();
        }
    }
}
