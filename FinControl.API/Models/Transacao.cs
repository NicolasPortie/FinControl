using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? ContaId { get; set; }
        public int? ContaDestinoId { get; set; }
        public int? CartaoCreditoId { get; set; }
        public int? FaturaId { get; set; }
        public int CategoriaId { get; set; }
        public int? SubCategoriaId { get; set; }
        public int? PagamentoRecorrenteId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public StatusTransacao Status { get; set; }
        public DateTime Data { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Conta? Conta { get; set; }
        public Conta? ContaDestino { get; set; }
        public CartaoCredito? CartaoCredito { get; set; }
        public Fatura? Fatura { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public SubCategoria? SubCategoria { get; set; }
        public PagamentoRecorrente? PagamentoRecorrente { get; set; }
        public Parcela? Parcela { get; set; }
    }
}
