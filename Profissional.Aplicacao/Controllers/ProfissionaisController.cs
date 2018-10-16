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
    public class ProfissionaisController : Controller
    {
        private readonly ProfissionalService _pfService;
        private readonly TelefoneService _tfService;
        private readonly EnderecoService _edService;

        public ProfissionaisController([FromServices]ProfissionalService pfService, 
            [FromServices]TelefoneService tfService, [FromServices]EnderecoService edService)
        {
            _pfService = pfService;
            _tfService = tfService;
            _edService = edService;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> SaveAsync([FromRoute]string token, [FromBody]Dominio.Entidades.Profissional profissional)
        {
            try
            {
                var pf = await _pfService.SaveAsync(profissional, token);
                await _tfService.SaveAsync(pf.Telefone, token);
                await _edService.SaveAsync(pf.Endereco, token);

                return Ok("Profissional salvo com sucesso.");
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
                var profissionais = await _pfService.GetAllAsync(idCliente, token);
                var telefones = await _tfService.GetAllAsync(profissionais.Select(p => p.ID).ToList(), token);
                var enderecos = await _edService.GetAllAsync(profissionais.Select(p => p.ID).ToList(), token);

                foreach (var profissional in profissionais)
                {
                    profissional.Telefone = telefones.FirstOrDefault(t => t.ProfissionalId.Equals(profissional.ID));
                    profissional.Endereco = enderecos.FirstOrDefault(e => e.ProfissionalId.Equals(profissional.ID));
                }

                return Ok(profissionais);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpGet("{idCliente:int}/{idProfissional:int}/{token}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int idCliente, [FromRoute]int idProfissional, [FromRoute]string token)
        {
            try
            {
                var profissional = await _pfService.GetByIdAsync(idProfissional, idCliente, token);
                profissional.Endereco = await _edService.GetByPfIdAsync(profissional.ID, token);
                profissional.Telefone = await _tfService.GetByPfIdAsync(profissional.ID, token);

                return Ok(profissional);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPut("{token}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]string token, [FromBody]Dominio.Entidades.Profissional profissional)
        {
            try
            {
                var pf = await _pfService.UpdateAsync(profissional, token);
                await _edService.UpdateAsync(pf.Endereco, token);
                await _tfService.UpdateAsync(pf.Telefone, token);

                return Ok("Profissional atualizado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> DeleteAsync([FromBody]Dominio.Entidades.Profissional profissional, [FromRoute]string token)
        {
            try
            { 
                await _pfService.RemoveAsync(profissional, token);
                //await _tfService.RemoveAsync(profissional.Telefone, token);
                //await _edService.RemoveAsync(profissional.Endereco, token);

                return Ok("Profissional removido com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPost("{idCliente:int}/{token}")]
        public async Task<IActionResult> GetByIdsAsync([FromRoute]int idCliente, [FromRoute]string token, [FromBody]IEnumerable<Base> ids)
        {
            try
            {
                var profissionais = await _pfService.GetBYIdListAsync(idCliente, token, ids.Select(b => b.ID));
                var telefones = await _tfService.GetAllAsync(profissionais.Select(p => p.ID).ToList(), token);
                var enderecos = await _edService.GetAllAsync(profissionais.Select(p => p.ID).ToList(), token);

                foreach (var profissional in profissionais)
                {
                    profissional.Telefone = telefones.FirstOrDefault(t => t.ProfissionalId.Equals(profissional.ID));
                    profissional.Endereco = enderecos.FirstOrDefault(e => e.ProfissionalId.Equals(profissional.ID));
                }

                return Ok(profissionais);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }
    }
}