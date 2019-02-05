using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profissional.Servico;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorias")]
    public class CategoriasController : Controller
    {
        private readonly CategoriaService _categorias;

        public CategoriasController(CategoriaService categorias)
        {
            _categorias = categorias;
        }

        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IActionResult> GetCategoriasAsync([FromRoute]string token, [FromRoute]int idCliente)
        {
            try
            {
                var result = await _categorias.GetAllAsync(idCliente, token);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não foi possível completar a operação.");
            }
        }
    }
}