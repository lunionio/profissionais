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
        [HttpGet("{token}")]
        public async Task<List<Dominio.Entidades.Servico>> Get([FromRoute]string token)
        {
            return await new ServicoServico().Get(token);
        }

        [HttpGet("{idProfissional:int}/{token}")]
        public List<Dominio.Entidades.Servico> GetByProfissional([FromRoute]int idProfissional, [FromRoute]string token)
        {
            return  new ServicoServico().GetByProfissional(idProfissional, token);
        }
        
        [HttpGet("{id:int}/{token}")]
        public async Task<Dominio.Entidades.Servico> Get([FromRoute]int id, [FromRoute]string token)
        {
            return await new ServicoServico().GetById(id, token);
        }

        [HttpGet("{idTipo:int}/{token}", Name = "GetByTipo")]
        public async Task<List<Dominio.Entidades.Servico>> GetByTipo(int idTipo, string token)
        {
            return await new ServicoServico().GetByServicoTipoId(idTipo, token);
        }
    }
}