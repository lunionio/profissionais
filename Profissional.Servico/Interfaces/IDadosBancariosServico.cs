using Profissional.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IDadosBancariosServico
    {
        Task<List<DadosBancarios>> GetByCodigoExterno(int codigoExterno);
        Task<List<DadosBancarios>> GetByCpfAsync(string cpf);
        Task<List<DadosBancarios>> GetAll();
        int Cadastrar(DadosBancarios conta);
        string Alterar(DadosBancarios conta);

    }
}
