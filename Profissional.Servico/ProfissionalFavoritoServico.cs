using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ProfissionalFavoritoServico : IService<Dominio.Entidades.ProfissionalFavorito>
    {
        private readonly ProfissionalFavoritoRep _profissionalFavoritoRep;
        public ProfissionalFavoritoServico(ProfissionalFavoritoRep profissionalFavoritoRep)
        {
            _profissionalFavoritoRep = profissionalFavoritoRep;
        }

        public Task<IEnumerable<ProfissionalFavorito>> GetAllAsync(int idCliente, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ProfissionalFavorito> GetByIdAsync(int entityId, int idCliente, string token)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ProfissionalFavorito entity, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfissionalFavorito> SaveAsync(ProfissionalFavorito entity, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    if(_profissionalFavoritoRep.GetSingle(x=> x.ProfissionalId == entity.ProfissionalId && x.IdEmpresa == entity.IdEmpresa && x.IdCliente == entity.IdCliente) == null)
                    {
                        entity.ID = _profissionalFavoritoRep.Add(entity);
                    }                    
                    return entity;
                }
                else
                {
                    throw new Exception("Token inválido!");
                }

                return default;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<ProfissionalFavorito> UpdateAsync(ProfissionalFavorito entity, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    _profissionalFavoritoRep.Update(entity);
                    return entity;
                }
                else
                {
                    throw new Exception("Token inválido!");
                }

                return default;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao efetuar requisição!", e);
            }
        }

        public async Task<IList<ProfissionalFavorito>> GetByEmpresa(int idCliente, int empresa, string token)
        {
            try
            {
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    return _profissionalFavoritoRep.GetList(x => x.IdCliente == idCliente && x.IdEmpresa == empresa, (p) => p.Profissional);
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
