namespace FinControl.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Conta> Contas { get; set; } = new List<Conta>();
        public ICollection<CartaoCredito> CartoesCredito { get; set; } = new List<CartaoCredito>();
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<Meta> Metas { get; set; } = new List<Meta>();
        public ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
        public ICollection<Planejamento> Planejamentos { get; set; } = new List<Planejamento>();
        public ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();
        public ICollection<ConversaChat> Conversas { get; set; } = new List<ConversaChat>();
        public ICollection<PromptPersonalizado> PromptsPersonalizados { get; set; } = new List<PromptPersonalizado>();
        public ConfiguracaoAlerta? ConfiguracaoAlerta { get; set; }
        public ConfiguracaoChat? ConfiguracaoChat { get; set; }
    }
}
