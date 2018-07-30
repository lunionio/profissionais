namespace Profissional.Dominio.Entidades
{
    public class Avaliacao : Base
    {
        public int Estrelas { get; set; }
        public int OportunidadeId { get; set; }
        public int CodigoExterno { get; set; }
        public int UsuarioAvaliadorId { get; set; }
        public int UsuarioAvaliadoId { get; set; }

    }
}
