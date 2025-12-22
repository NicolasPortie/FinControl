namespace FinControl.API.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime DataExpiracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataRevogacao { get; set; }
        public string? SubstituidoPor { get; set; }
        public string? CriadoPorIp { get; set; }
        public string? RevogadoPorIp { get; set; }
        public bool Ativo => DataRevogacao == null && DateTime.UtcNow < DataExpiracao;

        public Usuario Usuario { get; set; } = null!;
    }
}
