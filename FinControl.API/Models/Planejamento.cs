using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Planejamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public TipoPlanejamento Tipo { get; set; }
        public int MesInicio { get; set; }
        public int AnoInicio { get; set; }
        public int MesFim { get; set; }
        public int AnoFim { get; set; }
        public decimal ReceitaPrevista { get; set; }
        public decimal DespesaPrevista { get; set; }
        public decimal ReceitaRealizada { get; set; }
        public decimal DespesaRealizada { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public ICollection<PlanejamentoCategoria> Categorias { get; set; } = new List<PlanejamentoCategoria>();
    }
}
