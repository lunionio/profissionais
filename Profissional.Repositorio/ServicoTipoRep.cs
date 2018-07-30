using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;
using Profissional.Repositoriox;

namespace Profissional.Repositorio
{
    public class ServicoTipoRep: BaseRep<ServicoTipo>, IServicoTipo
    {
        private Contexto db = new Contexto();

        public async Task<ServicoTipo> GetByIdAsync(int id)
        {
            return await db.ServicoTipo.FirstAsync(c => c.ID == id);
        }
    }
}
