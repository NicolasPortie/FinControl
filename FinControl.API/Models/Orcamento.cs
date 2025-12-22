namespace FinControl.API.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int? SubCategoriaId { get; set; }
        public decimal ValorLimite { get; set; }
        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public bool AlertaAtivado { get; set; }
        public int? PercentualAlerta { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;
        public SubCategoria? SubCategoria { get; set; }
    }
}
