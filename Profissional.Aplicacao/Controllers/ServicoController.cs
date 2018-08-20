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

        public async Task<List<Dominio.Entidades.Servico>> Get(string token, int idCliente)
        {
            return await new ServicoServico().Get(token, idCliente);
        }

        public List<Dominio.Entidades.Servico> GetByProfissional(int idProfissional, string token, int idCliente)
        {
            return  new ServicoServico().GetByProfissional(idProfissional, token, idCliente);
        }
        

        public async Task<Dominio.Entidades.Servico> Get(int id, string token, int idCliente)
        {
            return await new ServicoServico().GetById(id, token, idCliente);
        }


        [HttpGet("{id}", Name = "GetByTipo")]
        public async Task<List<Dominio.Entidades.Servico>> GetByTipo(int idTipo, string token, int idCliente)
        {
            return await new ServicoServico().GetByServicoTipoId(idTipo, token, idCliente);
        }
    }
}