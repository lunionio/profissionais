using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;
using Profissional.Repositoriox;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Repositorio
{
   public class AvaliacaoRep : BaseRep<Avaliacao>, IAvaliacao
    {
        private Contexto db = new Contexto();



        public async Task<List<Avaliacao>> GetByAvaliado(int idAvaliado)
        {
            return await db.Avaliacao.Where(c => c.UsuarioAvaliadoId == idAvaliado && c.Ativo == true).ToListAsync();
        }

        public async Task<List<Avaliacao>> GetByAvaliadorAsync(int idAvaliador)
        {
            return await db.Avaliacao.Where(c => c.UsuarioAvaliadorId == idAvaliador && c.Ativo == true).ToListAsync();
        }

        public async Task<List<Avaliacao>> GetByCodigoExterno(int codigoExterno)
        {
            return await db.Avaliacao.Where(c => c.CodigoExterno == codigoExterno && c.Ativo == true).ToListAsync();
        }

        public async Task<Avaliacao> GetById(int id)
        {
            return await db.Avaliacao.FirstAsync(c => c.ID == id && c.Ativo == true);
        }

        public async Task<List<Avaliacao>> GetByOportunidade(int idOportunidade)
        {
            return await db.Avaliacao.Where(c => c.OportunidadeId == idOportunidade && c.Ativo == true).ToListAsync();
        }
    }
}
