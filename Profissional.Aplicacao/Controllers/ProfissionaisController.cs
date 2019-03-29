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
        private readonly UrlService _urlService;

        public ProfissionaisController([FromServices]ProfissionalService pfService, 
            [FromServices]TelefoneService tfService, [FromServices]EnderecoService edService, [FromServices]UrlService urlService)
        {
            _pfService = pfService;
            _tfService = tfService;
            _edService = edService;
            _urlService = urlService;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> SaveAsync([FromRoute]string token, [FromBody]Dominio.Entidades.Profissional profissional)
        {
            try
            {
                var pf = await _pfService.SaveAsync(profissional, token);
                if (pf.Telefone != null)
                {
                    pf.Telefone = await _tfService.SaveAsync(pf.Telefone, token);
                }

                if (pf.Endereco != null)
                {
                    pf.Endereco = await _edService.SaveAsync(pf.Endereco, token);
                }

                return Ok(pf);
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

                var ids = new List<int>();

                foreach (var item in pServicos)
                {
                    if(item.Profissional != null)
                    {
                        ids.Add(item.Profissional.ID);
                    }
                }

                var telefones = _tfService.GetAllAsync(ids, token);
                var enderecos = _edService.GetAllAsync(ids, token);

                foreach (var s in pServicos)
                {
                    if (s.Profissional != null)
                    {
                        s.Profissional.Telefone = telefones.FirstOrDefault(t => t.ProfissionalId.Equals(s.Profissional.ID));
                        s.Profissional.Endereco = enderecos.FirstOrDefault(e => e.ProfissionalId.Equals(s.Profissional.ID));
                    }
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
                pService.Profissional.Endereco = _edService.GetByPfIdAsync(pService.Profissional.ID, token);
                pService.Profissional.Telefone = _tfService.GetByPfIdAsync(pService.Profissional.ID, token);

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
                var telefones = _tfService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);
                var enderecos = _edService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);

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
                var telefones = _tfService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);
                var enderecos = _edService.GetAllAsync(pServicos.Select(p => p.Profissional.ID).ToList(), token);

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

        [HttpGet("{idCliente:int}/{userId:int}/{token}")]
        public async Task<IActionResult> GetByUserIdAsync([FromRoute]int idCliente, [FromRoute]string token, [FromRoute]int userId)
        {
            try
            {
                var pServico = await _pfService.GetByUserIdAsync(idCliente, token, userId);
                var telefone = _tfService.GetByPfIdAsync(pServico.Profissional.ID, token);
                var endereco = _edService.GetByPfIdAsync(pServico.Profissional.ID, token);

                pServico.Profissional.Telefone = telefone;
                pServico.Profissional.Endereco = endereco;

                return Ok(pServico);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IActionResult> GetURLAsync([FromRoute]int idCliente, [FromRoute]string token)
        {
            try
            {
                var response = default(IEnumerable<ProfissionalXUrl>);
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    response = _urlService.GetAll(idCliente);
                }
                else
                {
                    throw new Exception("Token inválido.");
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> SaveURLAsync([FromRoute]string token, [FromBody]ProfissionalXUrl url)
        {
            try
            {
                var response = default(ProfissionalXUrl);
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    response = _urlService.Save(url);
                }
                else
                {
                    throw new Exception("Token inválido.");
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }

        [HttpGet("{idCliente:int}/{profissionalId:int}/{token}")]
        public async Task<IActionResult> GetURLByProfissionalAsync([FromRoute]int profissionalId, [FromRoute]int idCliente, [FromRoute]string token)
        {
            try
            {
                var response = default(IEnumerable<ProfissionalXUrl>);
                if (await SeguracaServ.ValidaTokenAsync(token))
                {
                    response = _urlService.GetByProfissionalId(idCliente, profissionalId);
                }
                else
                {
                    throw new Exception("Token inválido.");
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }
    }
}