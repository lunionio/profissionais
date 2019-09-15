using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IProfissionalFavoritoServico
    {
        Task<IList<Profissional.Dominio.Entidades.ProfissionalFavorito>> GetByEmpresaId(int empresaId, string token);

        Task Add(Dominio.Entidades.ProfissionalFavorito model, string token);

        Task<Dominio.Entidades.ProfissionalFavorito> Update(Dominio.Entidades.ProfissionalFavorito model, string token);
    }
}
