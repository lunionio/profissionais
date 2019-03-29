using System;
using System.Collections.Generic;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class ProfissionalFormacao : Base
    {
        public string Instituicao { get; set; }
        public DateTime InicioCurso { get; set; }
        public DateTime FinalCurso { get; set; }

        public int? ProfissionalId { get; set; }
        public int? CodigoExterno { get; set; }
    }
}
