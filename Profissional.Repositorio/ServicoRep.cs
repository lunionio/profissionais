
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

        public async Task<Servico> GetByIdAsync(int id)
        {
            return await new Contexto().Servico.FirstAsync(c => c.ID == id && c.Ativo == true);
        }

        public async Task<List<Servico>> GetByServicoTipoId(int idTipo)
        {
            return await  new Contexto().Servico.Where(c => c.ServicoTipoId == idTipo && c.Ativo == true).ToListAsync();
        }


    }
}
