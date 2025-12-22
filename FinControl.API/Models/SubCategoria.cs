namespace FinControl.API.Models
{
    public class SubCategoria
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Categoria Categoria { get; set; } = null!;
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
