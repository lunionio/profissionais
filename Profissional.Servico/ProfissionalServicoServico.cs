using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
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

        public int Cadastrar(ProfissionalServico obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                {
                    obj.DataCriacao = DateTime.UtcNow;
                    obj.DataEdicao = DateTime.UtcNow;
                    return _Rep.Add(obj);
                }
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<ProfissionalServico>> GetAll(string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                    return await _Rep.GetAll();
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
    }
}
