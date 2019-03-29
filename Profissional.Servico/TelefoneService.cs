using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class TelefoneService : IService<Telefone>
    {
        private readonly TelefoneRepository _tfRepository;

        public TelefoneService(TelefoneRepository tfRepository)
        {
            _tfRepository = tfRepository;
        }

        public async Task<Telefone> SaveAsync(Telefone entity, string token)
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

                        entity.ID = _tfRepository.Add(entity);
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

        public IEnumerable<Telefone> GetAllAsync(List<int> profissionaisIds, string token)
        {
            try
            {
                //if(await SeguracaServ.ValidaTokenAsync(token))
                //{
                    var telefones = _tfRepository.GetList(e => profissionaisIds.Contains(e.ProfissionalId));
                    return telefones;
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

        public Telefone GetByPfIdAsync(int profissionalId, string token)
        {
            try
            {
                //if (await SeguracaServ.ValidaTokenAsync(token))
                //{
                    var telefone = _tfRepository.GetList(e => e.ProfissionalId.Equals(profissionalId)).SingleOrDefault();
                    return telefone;
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

        public async Task<Telefone> UpdateAsync(Telefone entity, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    entity.DataEdicao = DateTime.UtcNow;
                    _tfRepository.Update(entity);

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

        public async Task RemoveAsync(Telefone entity, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    _tfRepository.Remove(entity);
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

        public async Task<IEnumerable<Telefone>> GetAllAsync(int idCliente, string token)
        {
            try
            { 
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    var telefones = _tfRepository.GetList(e => e.IdCliente.Equals(idCliente));
                    return telefones;
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

        public async Task<Telefone> GetByIdAsync(int entityId, int idCliente, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    var telefone = _tfRepository.GetList(e => e.IdCliente.Equals(idCliente) 
                        && e.ID.Equals(entityId)).SingleOrDefault();

                    return telefone;
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
