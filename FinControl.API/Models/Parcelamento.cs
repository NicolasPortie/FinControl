namespace FinControl.API.Models
{
    public class Parcelamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? CartaoCreditoId { get; set; }
        public int CategoriaId { get; set; }
        public int? SubCategoriaId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public CartaoCredito? CartaoCredito { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public SubCategoria? SubCategoria { get; set; }
        public ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();
    }
}
