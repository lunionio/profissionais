using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IDadosBancarios
    {
        Task<List<DadosBancarios>> GetByCodigoExterno(int codigoExterno);
        Task<List<DadosBancarios>> GetByCpf(string cpf);


    }
}
