using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IServicoServico
    {
        Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo, string token, int idCliente);
        Task<Dominio.Entidades.Servico> GetById(int id, string token, int idCliente);
        Task<List<Dominio.Entidades.Servico>> Get(string token, int idCliente);
        List<Dominio.Entidades.Servico> GetByProfissional(int idProfissional, string token, int idCliente);

    }
}
