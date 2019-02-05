using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;
using System.Threading.Tasks;

namespace Profissional.Repositorio
{
    public class ServicoTipoRep: BaseRep<ServicoTipo>, IServicoTipo
    {
        private Contexto db = new Contexto();

        public async Task<ServicoTipo> GetByIdAsync(int id, int idCliente)
        {
            return await db.ServicoTipo.FirstAsync(c => c.ID == id && c.IdCliente.Equals(idCliente));
        }
    }
}
