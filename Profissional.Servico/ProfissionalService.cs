using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ProfissionalService : IService<Dominio.Entidades.Profissional>
    {
        private readonly ProfissionalRepository _pfRepository;

        public ProfissionalService(ProfissionalRepository profissionalRepository)
        {
            _pfRepository = profissionalRepository;
        }

        public async Task<Dominio.Entidades.Profissional> SaveAsync(Dominio.Entidades.Profissional entity, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    if (entity.ID == 0)
                    {
                        entity.DataCriacao = DateTime.UtcNow;
                        entity.DataEdicao = DateTime.UtcNow;
                        entity.Ativo = true;
                        var pfId = _pfRepository.Add(entity);

                        entity.Endereco.ProfissionalId = pfId;
                        entity.Telefone.ProfissionalId = pfId;
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

        public async Task<IEnumerable<Dominio.Entidades.Profissional>> GetAllAsync(int idCliente, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var result = _pfRepository.GetList(p => p.IdCliente.Equals(idCliente));
                    return result;
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

        public async Task<Dominio.Entidades.Profissional> GetByIdAsync(int entityId, int idCliente, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var result = _pfRepository.GetList(p => p.IdCliente.Equals(idCliente) && p.ID.Equals(entityId)).SingleOrDefault();
                    return result;
                }
                else
                {
                    throw new Exception("Token inválido.");
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<Dominio.Entidades.Profissional> UpdateAsync(Dominio.Entidades.Profissional entity, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    entity.DataEdicao = DateTime.UtcNow;
                    _pfRepository.Update(entity);

                    return entity;
                }
                else
                {
                    throw new Exception("Token inválido.");
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task RemoveAsync(Dominio.Entidades.Profissional entity, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    _pfRepository.Remove(entity);
                }
                else
                {
                    throw new Exception("Token inválido.");
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<IEnumerable<Dominio.Entidades.Profissional>> GetBYIdListAsync(int idCliente, string token, IEnumerable<int> ids)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var result = _pfRepository.GetList(p => ids.Contains(p.ID));
                    return result;
                }
                else
                {
                    throw new Exception("Token inválido.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }

        }
    }
}