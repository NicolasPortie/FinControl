using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public TipoTransacao? Tipo { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public ICollection<SubCategoria> SubCategorias { get; set; } = new List<SubCategoria>();
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
