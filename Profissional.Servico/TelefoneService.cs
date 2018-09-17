using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class TelefoneService
    {
        private readonly TelefoneRepository _tfRepository;

        public TelefoneService(TelefoneRepository tfRepository)
        {
            _tfRepository = tfRepository;
        }

        public async Task SaveAsync(Telefone telefone, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    telefone.DataCriacao = DateTime.UtcNow;
                    telefone.DataEdicao = DateTime.UtcNow;
                    telefone.Ativo = true;

                    var tfId = _tfRepository.Add(telefone);
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

        public async Task<IEnumerable<Telefone>> GetAllAsync(List<int> profissionaisIds, string token)
        {
            try
            {
                if(await SeguracaServ.validaTokenAsync(token))
                {
                    var telefones = _tfRepository.GetList(e => profissionaisIds.Contains(e.ProfissionalId));
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

        public async Task<Telefone> GetByPfIdAsync(int profissionalId, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    var telefone = _tfRepository.GetList(e => e.ProfissionalId.Equals(profissionalId)).SingleOrDefault();
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

        public async Task UpdateAsync(Telefone telefone, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    telefone.DataEdicao = DateTime.UtcNow;
                    _tfRepository.Update(telefone);
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

        public async Task RemoveAsync(Telefone telefone, string token)
        {
            try
            {
                if (await SeguracaServ.validaTokenAsync(token))
                {
                    _tfRepository.Remove(telefone);
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
