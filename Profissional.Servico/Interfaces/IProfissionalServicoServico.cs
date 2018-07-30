using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IProfissionalServicoServico
    {
        Task<List<ProfissionalServico>> GetAll();
        int Cadastrar(ProfissionalServico obj);
        void Alterar(ProfissionalServico obj);
        void Remover(ProfissionalServico obj);

    }
}
