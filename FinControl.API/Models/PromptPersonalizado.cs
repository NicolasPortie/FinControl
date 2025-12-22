using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class PromptPersonalizado
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoPrompt Tipo { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public bool Favorito { get; set; }
        public int VezesUtilizado { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
