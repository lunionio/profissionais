
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;
using Profissional.Repositoriox;

namespace Profissional.Repositorio
{
    public class ServicoRep : BaseRep<Servico>, IServico
    {

        private Contexto db = new Contexto();

        public async Task<Servico> GetByIdAsync(int id, int idCliente)
        {
            return await db.Servico.FirstAsync(c => c.ID == id 
            && c.Ativo == true && c.IdCliente.Equals(idCliente));
        }

        public List<Servico> GetByProfissional(int idProfissional, int idCliente)
        {
            var ids = db.ProfissionalServico.Where(c => c.UsuarioId == idProfissional 
            && c.Ativo == true && c.IdCliente.Equals(idCliente)).ToList();

            var list = new List<Servico>();
            foreach (var item in ids)
            {
                list.Add(db.Servico.First(c => c.ID == item.ID));
            }
            return list;
        }


        public async Task<List<Servico>> GetByServicoTipoId(int idTipo, int idCliente)
        {
            return await new Contexto().Servico.Where(c => c.ServicoTipoId == idTipo 
            && c.Ativo == true && c.IdCliente.Equals(idCliente)).ToListAsync();
        }


    }
}
