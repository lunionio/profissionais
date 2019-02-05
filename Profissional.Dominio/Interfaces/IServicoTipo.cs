using Profissional.Dominio.Entidades;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public  interface IServicoTipo: IRepository<ServicoTipo>
    {
        Task<ServicoTipo> GetByIdAsync(int id, int idCliente);
    }
}
