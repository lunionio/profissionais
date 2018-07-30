using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profissional.Dominio.Entidades;
using Profissional.Servico;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/ServicoTipo")]
    public class ServicoTipoController : Controller
    {
        [HttpGet]
        public async Task<List<ServicoTipo>> GetAll()
        {
            return await new ServicoTipoServico().Get();
        }


        [HttpGet("{idCliente}", Name = "GetById")]
        public ServicoTipo GetById(int id)
        {
            return new ServicoTipoServico().Get(id);
        }
    }
}