using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profissional.Servico;
using Microsoft.AspNetCore.Cors;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class ServicoController : Controller
    {
        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IList<Dominio.Entidades.Servico>> Get([FromRoute]string token, [FromRoute]int idCliente)
        {
            return await new ServicoServico().Get(token, idCliente);
        }

        [HttpGet("{idCliente:int}/{idProfissional:int}/{token}")]
        public List<Dominio.Entidades.Servico> GetByProfissional([FromRoute]int idProfissional, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return  new ServicoServico().GetByProfissional(idProfissional, token, idCliente);
        }
        
        [HttpGet("{idCliente:int}/{id:int}/{token}")]
        public async Task<Dominio.Entidades.Servico> GetById([FromRoute]int id, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return await new ServicoServico().GetById(id, token, idCliente);
        }

        [HttpGet("{idCliente:int}/{idTipo:int}/{token}", Name = "GetByTipo")]
        public async Task<List<Dominio.Entidades.Servico>> GetByTipo(int idTipo, string token, int idCliente)
        {
            return await new ServicoServico().GetByServicoTipoId(idTipo, token, idCliente);
        }
    }
}