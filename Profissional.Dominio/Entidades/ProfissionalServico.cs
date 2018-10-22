using System.ComponentModel.DataAnnotations.Schema;

namespace Profissional.Dominio.Entidades
{
    public class ProfissionalServico: Base
    {
        public int UsuarioId { get; set; }
        public int ServicoId { get; set; }

        public Servico Servico { get; set; }

        [NotMapped]
        public Profissional Profissional { get; set; }
    }
}
