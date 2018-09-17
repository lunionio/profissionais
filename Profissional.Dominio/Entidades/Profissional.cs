using System;
using System.Collections.Generic;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class Profissional : Base
    {
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public IList<ProfissionalFormacao> Fomarcoes { get; set; }
    }
}
