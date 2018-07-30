using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IServico
    {
        Task<Servico> GetByIdAsync(int id);
        Task<List<Servico>> GetByServicoTipoId(int idTipo);
        List<Servico> GetByProfissional(int idProfissional);
    }
}
