namespace FinControl.API.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int ParcelamentoId { get; set; }
        public int? FaturaId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }
        public int? TransacaoId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Parcelamento Parcelamento { get; set; } = null!;
        public Fatura? Fatura { get; set; }
        public Transacao? Transacao { get; set; }
    }
}
