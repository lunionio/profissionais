using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class EnderecoService
    {
        private readonly EnderecoRepository _repository;

        public EnderecoService(EnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveAsync(Endereco endereco, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    endereco.DataCriacao = DateTime.UtcNow;
                    endereco.DataEdicao = DateTime.UtcNow;
                    endereco.Ativo = true;

                    var edId = _repository.Add(endereco);
                }
                else
                {
                    throw new Exception("Token inválido!");
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync(List<int> profissionaisIds, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var enderecos = _repository.GetList(t => profissionaisIds.Contains(t.ProfissionalId));
                    return enderecos;
                }
                else
                {
                    throw new Exception("Token inválido!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<Endereco> GetByPfIdAsync(int profissionalId, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    var endereco = _repository.GetList(e => e.ProfissionalId.Equals(profissionalId)).SingleOrDefault();
                    return endereco;
                }
                else
                {
                    throw new Exception("Token inválido!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task UpdateAsync(Endereco endereco, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    endereco.DataEdicao = DateTime.UtcNow;
                    _repository.Update(endereco);
                }
                else
                {
                    throw new Exception("Token inválido!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task RemoveAsync(Endereco endereco, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    _repository.Remove(endereco);
                }
                else
                {
                    throw new Exception("Token inválido!");
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }
    }
}
