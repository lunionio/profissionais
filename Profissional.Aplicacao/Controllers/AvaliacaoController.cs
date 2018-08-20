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
  

        [HttpPost("{obj}", Name = "Cadastrar")]
        public int Cadastrar(Avaliacao obj)
        {
            return _servico.Cadastrar(obj);
        }

        [HttpGet("{idAvaliado}", Name = "GetByAvaliado")]
        public Task<List<Avaliacao>> GetByAvaliado(int idAvaliado)
        {
            return _servico.GetByAvaliado(idAvaliado);
        }

        [HttpGet("{idAvaliador}", Name = "GetByAvaliador")]
        public Task<List<Avaliacao>> GetByAvaliador(int idAvaliador)
        {
            return _servico.GetByAvaliador(idAvaliador);
        }

        [HttpGet("{idOportunidade}", Name = "GetByCodigoExterno")]
        public Task<List<Avaliacao>> GetByCodigoExterno(int codigoExterno)
        {
            return _servico.GetByCodigoExterno(codigoExterno);
        }

        [HttpGet("{idOportunidade}", Name = "GetByOportunidade")]
        public Task<List<Avaliacao>> GetByOportunidade(int idOportunidade)
        {
            return _servico.GetByOportunidade(idOportunidade);
        }

        public async Task<List<Avaliacao>> GetAllAsync()
        {
            return await _servico.GetAllAsync();
        }
    }
}