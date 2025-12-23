namespace FinControl.API.DTOs.Categoria
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Icone { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
    }
}
