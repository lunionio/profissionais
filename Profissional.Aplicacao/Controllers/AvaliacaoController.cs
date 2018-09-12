using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Profissional.Dominio.Entidades;
using Profissional.Servico;
using Profissional.Servico.Interfaces;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class AvaliacaoController : Controller, IAvaliacaoServico
    {
        public AvaliacaoServico _servico { get; set; }

        public AvaliacaoController()
        {
            _servico = new AvaliacaoServico();
        }
  
        [HttpPost("{token}", Name = "Cadastrar")]
        public int Cadastrar([FromBody]Avaliacao obj, [FromRoute]string token)
        {
            return _servico.Cadastrar(obj, token);
        }

        [HttpGet("{idCliente:int}/{idAvaliado:int}/{token}", Name = "GetByAvaliado")]
        public Task<List<Avaliacao>> GetByAvaliado([FromRoute]int idAvaliado, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return _servico.GetByAvaliado(idAvaliado, token, idCliente);
        }

        [HttpGet("{idCliente:int}/{idAvaliador:int}/{token}", Name = "GetByAvaliador")]
        public Task<List<Avaliacao>> GetByAvaliador([FromRoute]int idAvaliador, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return _servico.GetByAvaliador(idAvaliador, token, idCliente);
        }

        [HttpGet("{idCliente:int}/{codigoExterno:int}/{token}", Name = "GetByCodigoExterno")]
        public Task<List<Avaliacao>> GetByCodigoExterno([FromRoute]int codigoExterno, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return _servico.GetByCodigoExterno(codigoExterno, token, idCliente);
        }

        [HttpGet("{idCliente:int}/{idOportunidade:int}/{token}", Name = "GetByOportunidade")]
        public Task<List<Avaliacao>> GetByOportunidade([FromRoute]int idOportunidade, [FromRoute]string token, [FromRoute]int idCliente)
        {
            return _servico.GetByOportunidade(idOportunidade, token, idCliente);
        }

        [HttpGet("{idCliente:int}/{token}")]
        public async Task<List<Avaliacao>> GetAllAsync([FromRoute]string token, [FromRoute]int idCliente)
        {
            return await _servico.GetAllAsync(token, idCliente);
        }
    }
}