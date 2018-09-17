using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class ProfissionalService
    {
        private readonly ProfissionalRepository _pfRepository;

        public ProfissionalService(ProfissionalRepository profissionalRepository)
        {
            _pfRepository = profissionalRepository;
        }

        public async Task<Dominio.Entidades.Profissional> SaveAsync(Dominio.Entidades.Profissional profissional, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    profissional.DataCriacao = DateTime.UtcNow;
                    profissional.DataEdicao = DateTime.UtcNow;
                    profissional.Ativo = true;
                    var pfId = _pfRepository.Add(profissional);

                    profissional.Endereco.ProfissionalId = pfId;
                    profissional.Telefone.ProfissionalId = pfId;

                    return profissional;
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

        public async Task<Dominio.Entidades.Profissional> GetByIdAsync(int profissionalId, int idCliente, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var result = _pfRepository.GetList(p => p.IdCliente.Equals(idCliente) && p.ID.Equals(profissionalId)).SingleOrDefault();
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

        public async Task<Dominio.Entidades.Profissional> UpdateAsync(Dominio.Entidades.Profissional profissional, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    profissional.DataEdicao = DateTime.UtcNow;
                    _pfRepository.Update(profissional);

                    return profissional;
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

        public async Task RemoveAsync(Dominio.Entidades.Profissional profissional, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    _pfRepository.Remove(profissional);
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
    }
}