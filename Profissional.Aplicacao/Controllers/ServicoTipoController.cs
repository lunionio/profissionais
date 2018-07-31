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
        [HttpGet]
        public async Task<List<ServicoTipo>> GetAll(string token, int idCliente)
        {
            return await new ServicoTipoServico().Get(token, idCliente);
        }


        [HttpGet("{idCliente}", Name = "GetById")]
        public async Task<ServicoTipo> GetById(int id, string token, int idCliente)
        {
            return await new ServicoTipoServico().Get(id, token, idCliente);
        }
    }
}