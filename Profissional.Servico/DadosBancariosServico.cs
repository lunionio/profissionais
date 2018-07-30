using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class DadosBancariosServico : IDadosBancariosServico
    {
        public string Alterar(DadosBancarios conta)
        {
            try
            {
                new DadosBancariosRep().Add(conta);
                return "Dados bancários alterados com sucesso!";
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar alterar os dados.");
            }
        }

        public int Cadastrar(DadosBancarios conta)
        {
            try
            {
               return new DadosBancariosRep().Add(conta);
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao tentar alterar os dados.");

            }
        }

        public async Task<List<DadosBancarios>> GetAll()
        {
            try
            {
                return await new DadosBancariosRep().GetAll();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao retornar os dados");
            }
        }

        public async Task<List<DadosBancarios>> GetByCodigoExterno(int codigoExterno)
        {
            try
            {
                return await new DadosBancariosRep().GetByCodigoExterno(codigoExterno);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao retornar os dados");

            }
        }

        public async Task<List<DadosBancarios>> GetByCpfAsync(string cpf)
        {
            try
            {
                return await new DadosBancariosRep().GetByCpf(cpf);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao retornar os dados");
            }
        }
    }
}
