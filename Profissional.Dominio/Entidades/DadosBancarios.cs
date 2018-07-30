using System;
using System.Collections.Generic;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class DadosBancarios: Base
    {
        public int CodigoExterno { get; set; }
        public int Ref { get; set; }
        public string Cpf { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string TitularNome { get; set; }
        public string TitularCPF { get; set; }
        public string Tipo { get; set; }

    }
}
