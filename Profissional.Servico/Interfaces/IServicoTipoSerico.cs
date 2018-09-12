using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IServicoTipoSerico
    {
        Task<List<ServicoTipo>> Get(string token, int idCliente);
        Task<ServicoTipo> Get(int id, string token, int idCliente);
    }
}
