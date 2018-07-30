using Profissional.Dominio.Entidades;

namespace Profissional.Dominio.Interfaces
{
    public interface IServicoTipo: IBase<ServicoTipo>
    {
        ServicoTipo GetById(int id);
    }
}
