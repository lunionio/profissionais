namespace Profissional.Dominio.Entidades
{
    public class ProfissionalServico: Base
    {
        public int UsuarioId { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
