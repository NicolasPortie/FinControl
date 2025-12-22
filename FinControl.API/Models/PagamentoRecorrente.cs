using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class PagamentoRecorrente
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? ContaId { get; set; }
        public int? CartaoCreditoId { get; set; }
        public int CategoriaId { get; set; }
        public int? SubCategoriaId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public FrequenciaRecorrencia Frequencia { get; set; }
        public int DiaVencimento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? ProximaGeracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Conta? Conta { get; set; }
        public CartaoCredito? CartaoCredito { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public SubCategoria? SubCategoria { get; set; }
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
