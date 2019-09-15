using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profissional.Servico;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProfissionalFavoritoController : Controller
    {
        private readonly ProfissionalFavoritoServico _profissionalFavoritoServico;
        public ProfissionalFavoritoController([FromServices]ProfissionalFavoritoServico profissionalFavoritoServico)
        {
            _profissionalFavoritoServico = profissionalFavoritoServico;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> SaveAsync([FromRoute]string token, [FromBody]Dominio.Entidades.ProfissionalFavorito profissional)
        {
            try
            {
                var pf = await _profissionalFavoritoServico.SaveAsync(profissional, token);               

                return Ok(pf);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPut("{token}", Name = "Update")]
        public async Task<IActionResult> UpdateAsync([FromRoute]string token, [FromBody]Dominio.Entidades.ProfissionalFavorito profissional)
        {
            try
            {
                var pf = await _profissionalFavoritoServico.UpdateAsync(profissional, token);

                return Ok("Profissional atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPost("{idCliente:int}/{idEmpresa:int}/{token}")]
        public async Task<IActionResult> GetByIdsAsync([FromRoute]int idCliente, [FromRoute]int idEmpresa,  [FromRoute]string token)
        {
            try
            {
                var pServicos = await _profissionalFavoritoServico.GetByEmpresa(idCliente,idEmpresa, token);               

                return Ok(pServicos);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }
    }
}