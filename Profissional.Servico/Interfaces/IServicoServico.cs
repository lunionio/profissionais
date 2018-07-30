using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IServicoServico
    {
        Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo);
        Task<Dominio.Entidades.Servico> GetById(int id);
        Task<List<Dominio.Entidades.Servico>> Get();
    }
}
