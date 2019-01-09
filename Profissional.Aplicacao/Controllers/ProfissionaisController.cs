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
                var pServicos = await _pfService.GetProfissionalServicos(idCliente, token);
                var telefones = await _tfService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);
                var enderecos = await _edService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);

                foreach (var s in pServicos)
                {
                    s.Profissional.Telefone = telefones.FirstOrDefault(t => t.ProfissionalId.Equals(s.Profissional.ID));
                    s.Profissional.Endereco = enderecos.FirstOrDefault(e => e.ProfissionalId.Equals(s.Profissional.ID));
                }

                return Ok(pServicos);
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
                var pService = await _pfService.GetProfissionalServicoByIdAsync(idProfissional, idCliente, token);
                pService.Profissional.Endereco = await _edService.GetByPfIdAsync(pService.Profissional.ID, token);
                pService.Profissional.Telefone = await _tfService.GetByPfIdAsync(pService.Profissional.ID, token);

                return Ok(pService);
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
        public async Task<IActionResult> GetByIdsAsync([FromRoute]int idCliente, [FromRoute]string token, [FromBody]IEnumerable<int> ids)
        {
            try
            {
                var pServicos = await _pfService.GetByIdListAsync(idCliente, token, ids);
                var telefones = await _tfService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);
                var enderecos = await _edService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);

                foreach (var pServico in pServicos)
                {
                    pServico.Profissional.Telefone = telefones.FirstOrDefault(t => t.ProfissionalId.Equals(pServico.Profissional.ID));
                    pServico.Profissional.Endereco = enderecos.FirstOrDefault(e => e.ProfissionalId.Equals(pServico.Profissional.ID));
                }

                return Ok(pServicos);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPost("{idCliente:int}/{token}")]
        public async Task<IActionResult> GetByUserIdsAsync([FromRoute]int idCliente, [FromRoute]string token, [FromBody]IEnumerable<int> ids)
        {
            try
            {
                var pServicos = await _pfService.GetByUserIdListAsync(idCliente, token, ids);
                var telefones = await _tfService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);
                var enderecos = await _edService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);

                foreach (var pServico in pServicos)
                {
                    pServico.Profissional.Telefone = telefones.FirstOrDefault(t => t.ProfissionalId.Equals(pServico.Profissional.ID));
                    pServico.Profissional.Endereco = enderecos.FirstOrDefault(e => e.ProfissionalId.Equals(pServico.Profissional.ID));
                }

                return Ok(pServicos);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }
    }
}