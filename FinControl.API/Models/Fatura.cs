using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Fatura
    {
        public int Id { get; set; }
        public int CartaoCreditoId { get; set; }
        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public DateTime DataFechamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public StatusFatura Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public CartaoCredito CartaoCredito { get; set; } = null!;
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
