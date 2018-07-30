using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profissional.Servico;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Servico")]
    public class ServicoController : Controller
    {

        public async Task<List<Dominio.Entidades.Servico>> Get()
        {
            return await new ServicoServico().Get();
        }

        //[HttpGet("{id}", Name = "GetById")]
        //public Dominio.Entidades.Servico GetById(int id)
        //{
        //    return new ServicoServico().GetById(id);
        //}

        [HttpGet("{id}", Name = "GetByTipo")]
        public async Task<List<Dominio.Entidades.Servico>> GetByTipo(int idTipo)
        {
            return await new ServicoServico().GetByServicoTipoId(idTipo);
        }
    }
}