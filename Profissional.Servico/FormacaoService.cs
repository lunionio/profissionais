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
    public class FormacaoService : IService<ProfissionalFormacao>
    {
        private FormacaoRepository _repository;

        public FormacaoService(FormacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProfissionalFormacao>> GetAllAsync(int idCliente, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    var result = _repository.GetList(f => f.IdCliente.Equals(idCliente));
                    return result;
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

        public async Task<ProfissionalFormacao> GetByIdAsync(int entityId, int idCliente, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    var formacao = _repository.GetList(f => f.ID.Equals(entityId) 
                        && f.IdCliente.Equals(idCliente)).SingleOrDefault();
                    return formacao;
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

        public async Task RemoveAsync(ProfissionalFormacao entity, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
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

        public async Task<ProfissionalFormacao> SaveAsync(ProfissionalFormacao entity, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    entity.DataCriacao = DateTime.UtcNow;
                    entity.DataEdicao = DateTime.UtcNow;
                    entity.Ativo = true;
                    entity.ID = _repository.Add(entity);

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

        public async Task<ProfissionalFormacao> UpdateAsync(ProfissionalFormacao entity, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
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
            catch(Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<IEnumerable<ProfissionalFormacao>> GetByProfissionalIdAsync(int idCliente, int idProfissional, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    var result = _repository.GetList(f => f.IdCliente.Equals(idCliente) 
                        && f.ProfissionalId.Equals(idProfissional));
                    return result;
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
