using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IServico
    {
        Servico GetById(int id);
        Task<List<Servico>> GetByServicoTipoId(int idTipo);
    }
}
