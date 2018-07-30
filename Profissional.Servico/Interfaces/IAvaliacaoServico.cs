using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IAvaliacaoServico
    {
        Task<List<Avaliacao>> GetByOportunidade(int idOportunidade);
        Task<List<Avaliacao>> GetByCodigoExterno(int codigoExterno);
        Task<List<Avaliacao>> GetByAvaliador(int idAvaliador);
        Task<List<Avaliacao>> GetByAvaliado(int idAvaliado);
        Task<List<Avaliacao>> GetAllAsync();

        int Cadastrar(Avaliacao obj);

    }
}
