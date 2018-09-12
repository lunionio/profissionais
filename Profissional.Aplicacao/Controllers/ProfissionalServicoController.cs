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
        public int Cadastrar([FromBody]ProfissionalServico obj, [FromRoute]string token)
        {
            return _servico.Cadastrar(obj, token);
        }

        [HttpGet("{token}")]
        public async Task<List<ProfissionalServico>> GetAll([FromRoute]string token)
        {
            return await _servico.GetAll(token);
        }

        [HttpDelete("{token}")]
        public void Remover([FromBody]ProfissionalServico obj, [FromRoute]string token)
        {
            _servico.Remover(obj, token);
        }
    }
}