using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Profissional.Dominio.Entidades;
using Profissional.Servico;
using Profissional.Servico.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class ProfissionalServicoController : Controller, IProfissionalServicoServico
    {
        private ProfissionalServicoServico _servico = new ProfissionalServicoServico();

        [HttpPut("{token}")]
        public void Alterar([FromBody]ProfissionalServico obj, [FromRoute]string token)
        {
            _servico.Alterar(obj, token);
        }

        [HttpPost("{token}")]
        public async Task<ProfissionalServico> Cadastrar([FromBody]ProfissionalServico obj, [FromRoute]string token)
        {
            var ps = _servico.Cadastrar(obj, token);
            if(ps != null)
            {
                ps.Servico = await new ServicoController().GetById(ps.ServicoId, token, ps.IdCliente);
            }

            return ps;
        }

        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IList<ProfissionalServico>> GetAll([FromRoute]string token, [FromRoute]int idCliente)
        {
            return await _servico.GetAll(token, idCliente);
        }

        [HttpDelete("{token}")]
        public void Remover([FromBody]ProfissionalServico obj, [FromRoute]string token)
        {
            _servico.Remover(obj, token);
        }
    }
}