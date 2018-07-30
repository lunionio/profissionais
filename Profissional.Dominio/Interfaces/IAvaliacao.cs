using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IAvaliacao
    {
        Task<Avaliacao> GetById(int id);
        Task<List<Avaliacao>> GetByCodigoExterno(int codigoExterno);
        Task<List<Avaliacao>> GetByOportunidade(int idOportunidade);
        Task<List<Avaliacao>> GetByAvaliadorAsync(int idAvaliador);
        Task<List<Avaliacao>> GetByAvaliado(int idAvaliado);

    }
}
