using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Linq;


namespace Profissional.Servico
{
    public class AvaliacaoServico : IAvaliacaoServico
    {
        public int Cadastrar(Avaliacao obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                {
                    if (obj.ID == 0)
                    {
                        obj.DataCriacao = DateTime.UtcNow;
                        obj.DataEdicao = DateTime.UtcNow;
                        return new AvaliacaoRep().Add(obj);
                    }
                    else
                    {
                        obj.DataEdicao = DateTime.UtcNow;
                        new AvaliacaoRep().Update(obj);
                        return 1;
                    }
                }
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public bool Inserir(IEnumerable<Avaliacao> obj, string token)
        {
            try
            {
                if (SeguracaServ.validaToken(token))
                {
                    foreach (var item in obj)
                    {
                        if (item.ID == 0)
                        {
                            item.DataCriacao = DateTime.UtcNow;
                            item.DataEdicao = DateTime.UtcNow;
                            var r = new AvaliacaoRep().Add(item);
                        }
                        else
                        {
                            item.DataEdicao = DateTime.UtcNow;
                            new AvaliacaoRep().Update(item);
                        }
                    }

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IList<Avaliacao>> GetAllAsync(string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return new AvaliacaoRep().GetList(a => a.IdCliente.Equals(idCliente));
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByAvaliado(int idAvaliado, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByAvaliado(idAvaliado, idCliente);
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByAvaliador(int idAvaliador, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByAvaliadorAsync(idAvaliador, idCliente);
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByCodigoExterno(int idOportunidade, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                    return await new AvaliacaoRep().GetByCodigoExterno(idOportunidade, idCliente);
                else
                    throw new Exception("Token inválido!");

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }

        public async Task<List<Avaliacao>> GetByOportunidade(int idOportunidade, string token, int idCliente)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var r = await new AvaliacaoRep().GetByOportunidade(idOportunidade, idCliente);
                    return r;
                }
                else
                    throw new Exception("Token inválido!");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao efetuar requisição!");
            }
        }
    }
}
