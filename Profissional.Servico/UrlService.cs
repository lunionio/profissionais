using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class UrlService
    {
        private UrlRepository _repository;

        public UrlService(UrlRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProfissionalXUrl> GetAll(int idCliente)
        {
            try
            {
                var result = _repository.GetList(u => u.IdCliente.Equals(idCliente));
                return result;
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possível recuperar as urls dos profissionais.", e);
            }
        }

        public ProfissionalXUrl GetById(int entityId, int idCliente)
        {
            try
            {
                var result = _repository.GetSingle(u => u.ID.Equals(entityId) && u.IdCliente.Equals(idCliente));
                return result;
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possível recuperar a url do profissional.", e);
            }
        }

        public void Remove(ProfissionalXUrl entity)
        {
            try
            {
                _repository.Remove(entity);
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possível remover a url informada.", e);
            }
        }

        public ProfissionalXUrl Save(ProfissionalXUrl entity)
        {
            try
            {
                switch (entity.ID)
                {
                    case 0:
                        entity.DataCriacao = DateTime.UtcNow;
                        entity.DataEdicao = DateTime.UtcNow;
                        entity.Ativo = true;

                        entity.ID = _repository.Add(entity);
                        break;
                    default:
                        entity = Update(entity);
                        break;
                }

                return entity;
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possível completar a operação.", e);
            }
        }

        public ProfissionalXUrl Update(ProfissionalXUrl entity)
        {
            try
            {
                entity.DataEdicao = DateTime.UtcNow;
                _repository.Update(entity);

                return entity;
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possível salvar a url informada.", e);
            }
        }

        public IEnumerable<ProfissionalXUrl> GetByProfissionalId(int idCliente, int profissionalId)
        {
            try
            {
                var result = _repository.GetList(u => u.IdProfissional.Equals(profissionalId) && u.IdCliente.Equals(idCliente));
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível recuperar a url do profissional.", e);
            }
        }
    }
}
