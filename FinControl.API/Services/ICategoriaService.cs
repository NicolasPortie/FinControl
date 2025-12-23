using FinControl.API.DTOs.Categoria;

namespace FinControl.API.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaResponse>> ListarTodasAsync();
        Task<CategoriaResponse?> ObterPorIdAsync(int id);
        Task<CategoriaResponse> CriarAsync(CategoriaRequest request);
        Task<bool> AtualizarAsync(int id, CategoriaRequest request);
        Task<bool> DeletarAsync(int id);
    }
}
