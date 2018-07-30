using System.Linq;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;
using Profissional.Repositoriox;

namespace Profissional.Repositorio
{
    public class ServicoTipoRep: BaseRep<ServicoTipo>, IServicoTipo
    {
        public ServicoTipo GetById(int id)
        {
            var context = new Contexto();
            return context.ServicoTipo.Where(c => c.ID == id).First();
        }
    }
}
