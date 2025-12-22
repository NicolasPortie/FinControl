namespace FinControl.API.Models
{
    public class ConfiguracaoAlerta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public bool AlertaOrcamento { get; set; }
        public int PercentualAlertaOrcamento { get; set; }
        public bool AlertaSaldoBaixo { get; set; }
        public decimal ValorMinimoSaldo { get; set; }
        public bool AlertaFaturaVencimento { get; set; }
        public int DiasAntesFatura { get; set; }
        public bool AlertaMetaAtingida { get; set; }
        public bool AlertaPagamentoRecorrente { get; set; }
        public int DiasAntesPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
