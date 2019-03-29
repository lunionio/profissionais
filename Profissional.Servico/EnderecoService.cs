using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class EnderecoService : IService<Endereco>
    {
        private readonly EnderecoRepository _repository;

        public EnderecoService(EnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Endereco> SaveAsync(Endereco entity, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    if (entity.ID == 0)
                    {
                        entity.DataCriacao = DateTime.UtcNow;
                        entity.DataEdicao = DateTime.UtcNow;
                        entity.Ativo = true;

                        entity.ID = _repository.Add(entity);
                    }
                    else
                    {
                        entity = await UpdateAsync(entity, token);
                    }
                    return entity;
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

        public IEnumerable<Endereco> GetAllAsync(List<int> profissionaisIds, string token)
        {
            try
            {
                //if (await SeguracaServ.ValidaTokenAsync(token))
                //{
                    var enderecos = _repository.GetList(t => profissionaisIds.Contains(t.ProfissionalId));
                    return enderecos;
                //}
                //else
                //{
                //    throw new Exception("Token inválido!");
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public Endereco GetByPfIdAsync(int profissionalId, string token)
        {
            try
            {
                //if(await SeguracaServ.ValidaTokenAsync(token))
                //{
                    var endereco = _repository.GetList(e => e.ProfissionalId.Equals(profissionalId)).SingleOrDefault();
                    return endereco;
                //}
                //else
                //{
                //    throw new Exception("Token inválido!");
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<Endereco> UpdateAsync(Endereco entity, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    entity.DataEdicao = DateTime.UtcNow;
                    _repository.Update(entity);

                    return entity;
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

        public async Task RemoveAsync(Endereco entity, string token)
        {
            try
            {
                if(await SeguracaServ.ValidaTokenAsync(token))
                {
                    _repository.Remove(entity);
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

        public async Task<IEnumerable<Endereco>> GetAllAsync(int idCliente, string token)
        {
            try
            {
                if(await SeguracaServ.ValidaTokenAsync(token))
                {
                    var enderecos = _repository.GetList(e => e.IdCliente.Equals(idCliente));
                    return enderecos;
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

        public async Task<Endereco> GetByIdAsync(int entityId, int idCliente, string token)
        {
            try
            {
                if(await SeguracaServ.ValidaTokenAsync(token))
                {
                    var endereco = _repository.GetList(e => e.ID.Equals(entityId) 
                        && e.IdCliente.Equals(idCliente)).SingleOrDefault();

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
    }
}
