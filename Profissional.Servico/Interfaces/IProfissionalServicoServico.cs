using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IProfissionalServicoServico
    {
        Task<IList<ProfissionalServico>> GetAll(string token, int idCliente);
        Task<ProfissionalServico> Cadastrar(ProfissionalServico obj, string token);
        void Alterar(ProfissionalServico obj, string token);
        void Remover(ProfissionalServico obj, string token);

    }
}
