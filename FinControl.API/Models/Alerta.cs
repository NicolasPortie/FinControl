using FinControl.API.Enums;

namespace FinControl.API.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public TipoAlerta Tipo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public StatusAlerta Status { get; set; }
        public int? ReferenciaId { get; set; }
        public string? ReferenciaTipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataVisualizacao { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
