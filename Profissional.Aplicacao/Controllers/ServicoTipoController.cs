using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profissional.Dominio.Entidades;
using Profissional.Servico;
using Microsoft.AspNetCore.Cors;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class ServicoTipoController : Controller
    {
        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IList<ServicoTipo>> GetAll([FromRoute]string token, [FromRoute]int idCliente)
        {
            return await new ServicoTipoServico().Get(token, idCliente);
        }

        [HttpGet("{idCliente:int}/{id:int}/{token}", Name = "GetById")]
        public async Task<ServicoTipo> GetById([FromRoute]int id, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return await new ServicoTipoServico().Get(id, token, idCliente);
        }
    }
}