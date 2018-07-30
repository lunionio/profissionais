using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;
using Profissional.Repositoriox;

namespace Profissional.Repositorio
{
    public class DadosBancariosRep : BaseRep<DadosBancarios>, IDadosBancarios
    {
        public async Task<List<DadosBancarios>> GetByCodigoExterno(int codigoExterno)
        {
            return await new Contexto().DadosBancarios.Where(c => c.CodigoExterno == codigoExterno && c.Ativo == true).ToListAsync();
        }

        public async Task<List<DadosBancarios>> GetByCpf(string cpf)
        {
            return await new Contexto().DadosBancarios.Where(c => c.Cpf == cpf && c.Ativo == true).ToListAsync();
        }
    }
}
