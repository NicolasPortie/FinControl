using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class ComandoChat
    {
        public int Id { get; set; }
        public int MensagemChatId { get; set; }
        public int UsuarioId { get; set; }
        public TipoPrompt TipoComando { get; set; }
        public string DadosExtraidos { get; set; } = string.Empty;
        public string? EntidadeCriada { get; set; }
        public int? EntidadeId { get; set; }
        public StatusComandoChat Status { get; set; }
        public string? MensagemErro { get; set; }
        public bool RequerConfirmacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataExecucao { get; set; }

        public MensagemChat MensagemChat { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
    }
}
