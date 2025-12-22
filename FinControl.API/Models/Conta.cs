using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public TipoConta Tipo { get; set; }
        public string? Banco { get; set; }
        public string? Agencia { get; set; }
        public string? NumeroConta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoAtual { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
