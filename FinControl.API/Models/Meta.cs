using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Meta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? ContaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal ValorObjetivo { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime? DataLimite { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }
        public StatusMeta Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Conta? Conta { get; set; }
    }
}
