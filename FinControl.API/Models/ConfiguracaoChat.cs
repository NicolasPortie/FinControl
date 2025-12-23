namespace FinControl.API.Models
{
    public class ConfiguracaoChat
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NomeModelo { get; set; } = "Padrao";
        public string? PromptSistema { get; set; }
        public int MaxTokensResposta { get; set; }
        public int MaxMensagensContexto { get; set; }
        public decimal Temperatura { get; set; }
        public bool ResumirConversasAntigas { get; set; }
        public bool IncluirDadosFinanceiros { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
