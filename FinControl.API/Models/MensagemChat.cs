using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class MensagemChat
    {
        public int Id { get; set; }
        public int ConversaChatId { get; set; }
        public RoleChat Role { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public int? TokensUtilizados { get; set; }
        public int Ordem { get; set; }
        public DateTime DataCriacao { get; set; }

        public ConversaChat ConversaChat { get; set; } = null!;
    }
}
