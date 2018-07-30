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

        public void Alterar(ProfissionalServico obj)
        {
            try
            {
                _Rep.Update(obj);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");

            }
        }

        public int Cadastrar(ProfissionalServico obj)
        {
            try
            {
                return  _Rep.Add(obj);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<ProfissionalServico>> GetAll()
        {
            try
            {
                return await _Rep.GetAll();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");
                
            }
        }

        public void Remover(ProfissionalServico obj)
        {
            try
            {
                _Rep.Remove(obj);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao efetuar requisição!");

            }
        }
    }
}
