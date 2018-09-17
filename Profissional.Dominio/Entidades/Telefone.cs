using System;
using System.Collections.Generic;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class Telefone : Base
    {
        public string Numero { get; set; }
        public int ProfissionalId { get; set; }
    }
}
