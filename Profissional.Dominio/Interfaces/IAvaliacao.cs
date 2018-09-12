using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IAvaliacao
    {
        Task<Avaliacao> GetById(int id, int idCliente);
        Task<List<Avaliacao>> GetByCodigoExterno(int codigoExterno, int idCliente);
        Task<List<Avaliacao>> GetByOportunidade(int idOportunidade, int idCliente);
        Task<List<Avaliacao>> GetByAvaliadorAsync(int idAvaliador, int idCliente);
        Task<List<Avaliacao>> GetByAvaliado(int idAvaliado, int idCliente);

    }
}
