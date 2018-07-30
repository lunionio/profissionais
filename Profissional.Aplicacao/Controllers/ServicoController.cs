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

        public List<Dominio.Entidades.Servico> GetByProfissional(int idProfissional)
        {
            return  new ServicoServico().GetByProfissional(idProfissional);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<Dominio.Entidades.Servico> GetById(int id)
        {
            return await new ServicoServico().GetById(id);
        }

        public Task<List<Dominio.Entidades.Servico>> GetByServicoTipoId(int idTipo)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("{id}", Name = "GetByTipo")]
        public async Task<List<Dominio.Entidades.Servico>> GetByTipo(int idTipo)
        {
            return await new ServicoServico().GetByServicoTipoId(idTipo);
        }
    }
}