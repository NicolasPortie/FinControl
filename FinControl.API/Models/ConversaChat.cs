namespace FinControl.API.Models
{
    public class ConversaChat
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Resumo { get; set; }
        public int TotalMensagens { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public ICollection<MensagemChat> Mensagens { get; set; } = new List<MensagemChat>();
    }
}
