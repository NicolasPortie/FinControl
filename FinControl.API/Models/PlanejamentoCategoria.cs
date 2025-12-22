namespace FinControl.API.Models
{
    public class PlanejamentoCategoria
    {
        public int Id { get; set; }
        public int PlanejamentoId { get; set; }
        public int CategoriaId { get; set; }
        public decimal ValorPrevisto { get; set; }
        public decimal ValorRealizado { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Planejamento Planejamento { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;
    }
}
