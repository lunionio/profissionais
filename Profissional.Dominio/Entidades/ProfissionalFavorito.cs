using System;
using System.Collections.Generic;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class ProfissionalFavorito
    {
        public int ID { get; set; }
        public int ProfissionalId { get; set; }
        public virtual Profissional Profissional { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCliente { get; set; }
    }
}
