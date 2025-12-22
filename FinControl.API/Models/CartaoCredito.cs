namespace FinControl.API.Models
{
    public class CartaoCredito
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Bandeira { get; set; }
        public string? UltimosDigitos { get; set; }
        public decimal Limite { get; set; }
        public int DiaFechamento { get; set; }
        public int DiaVencimento { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public ICollection<Fatura> Faturas { get; set; } = new List<Fatura>();
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
