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

        public async Task<List<Dominio.Entidades.Servico>> Get()
        {
            return await new ServicoServico().Get();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<Dominio.Entidades.Servico> GetById(int id)
        {
            return await new ServicoServico().GetById(id);
        }

        [HttpGet("{id}", Name = "GetByTipo")]
        public async Task<List<Dominio.Entidades.Servico>> GetByTipo(int idTipo)
        {
            return await new ServicoServico().GetByServicoTipoId(idTipo);
        }
    }
}