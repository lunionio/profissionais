using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IAvaliacaoServico
    {
        Task<List<Avaliacao>> GetByOportunidade(int idOportunidade, string token, int idCliente);
        Task<List<Avaliacao>> GetByCodigoExterno(int codigoExterno, string token, int idCliente);
        Task<List<Avaliacao>> GetByAvaliador(int idAvaliador, string token, int idCliente);
        Task<List<Avaliacao>> GetByAvaliado(int idAvaliado, string token, int idCliente);
        Task<IList<Avaliacao>> GetAllAsync(string token, int idCliente);

        int Cadastrar(Avaliacao obj, string token);

    }
}
