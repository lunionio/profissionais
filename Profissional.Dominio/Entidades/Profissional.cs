using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Profissional.Dominio.Entidades
{
    public class Profissional : Base
    {
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        [NotMapped]
        public IList<ProfissionalFormacao> Formacoes { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Avaliacao { get; set; }
        public Categoria Categoria { get; set; }
        public int? CategoriaId { get; set; }
    }
}
