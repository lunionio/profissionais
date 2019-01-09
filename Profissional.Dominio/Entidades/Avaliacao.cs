namespace Profissional.Dominio.Entidades
{
    public class Avaliacao : Base
    {
        public decimal Estrelas { get; set; }
        public int OportunidadeId { get; set; }
        public string CodigoExterno { get; set; }
        public int UsuarioAvaliadorId { get; set; }
        public int UsuarioAvaliadoId { get; set; }

    }
}
