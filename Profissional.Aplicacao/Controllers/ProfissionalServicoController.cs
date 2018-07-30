using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profissional.Dominio.Entidades;
using Profissional.Dominio.Interfaces;
using Profissional.Servico;
using Profissional.Servico.Interfaces;

namespace Profissional.Aplicacao.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class ProfissionalServicoController : Controller, IProfissionalServicoServico
    {
        private ProfissionalServicoServico _servico = new ProfissionalServicoServico();

        public void Alterar(ProfissionalServico obj)
        {
            _servico.Alterar(obj);
        }

        public int Cadastrar(ProfissionalServico obj)
        {
            return _servico.Cadastrar(obj);
        }

        public async Task<List<ProfissionalServico>> GetAll()
        {
            return await _servico.GetAll();
        }

        public void Remover(ProfissionalServico obj)
        {
            _servico.Remover(obj);
        }
    }
}