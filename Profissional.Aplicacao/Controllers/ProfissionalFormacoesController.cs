using Microsoft.AspNetCore.Mvc;
using Profissional.Dominio.Entidades;
using Profissional.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProfissionalFormacoesController : Controller
    {
        private FormacaoService _fService;

        public ProfissionalFormacoesController([FromServices]FormacaoService service)
        {
            _fService = service;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> SaveAsync([FromBody]ProfissionalFormacao formacao, [FromRoute]string token)
        {
            try
            {
                var pf = await _fService.SaveAsync(formacao, token);
                return Ok("Formação salva com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IActionResult> GetAllAsync([FromRoute]int idCliente, [FromRoute]string token)
        {
            try
            {
                var formacoes = await _fService.GetAllAsync(idCliente, token);
                return Ok(formacoes);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpGet("{idCliente:int}/{idFormacao:int}/{token}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int idCliente, [FromRoute]int idFormacao, [FromRoute]string token)
        {
            try
            {
                var formacao = await _fService.GetByIdAsync(idFormacao, idCliente, token);
                return Ok(formacao);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPut("{token}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]string token, [FromBody]ProfissionalFormacao formacao)
        {
            try
            {
                var result = await _fService.UpdateAsync(formacao, token);
                return Ok("Formação atualizada com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpDelete("{token}")]
        public async Task<IActionResult> DeleteAsync([FromBody]ProfissionalFormacao formacao, [FromRoute]string token)
        {
            try
            {
                await _fService.RemoveAsync(formacao, token);
                return Ok("Formação removida com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpGet("{idCliente:int}/{idProfissional:int}/{token}")]
        public async Task<IActionResult> GetByProfissionalIdAsync([FromRoute]string token, [FromRoute]int idProfissional, [FromRoute]int idCliente)
        {
            try
            {
                var formacoes = await _fService.GetByProfissionalIdAsync(idCliente, idProfissional, token);
                return Ok(formacoes);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }
    }
}
