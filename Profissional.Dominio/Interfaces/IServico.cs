using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IServico
    {
        Task<Servico> GetByIdAsync(int id, int idCliente);
        Task<List<Servico>> GetByServicoTipoId(int idTipo, int idCliente);
        List<Servico> GetByProfissional(int idProfissional, int idCliente);
    }
}
