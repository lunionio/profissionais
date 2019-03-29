using System;
using System.Collections.Generic;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class ProfissionalXUrl : Base
    {
        public string URL { get; set; }
        public int IdProfissional { get; set; }
        public byte[] Imagem { get; set; }

        public ProfissionalXUrl()
        {

        }
    }
}
