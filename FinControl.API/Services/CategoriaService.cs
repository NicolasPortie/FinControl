using FinControl.API.Data;
using FinControl.API.DTOs.Categoria;
using FinControl.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinControl.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaResponse>> ListarTodasAsync()
        {
            var categorias = await _context.Categorias
                .AsNoTracking()
                .OrderBy(c => c.Nome)
                .ToListAsync();

            return categorias.Select(c => new CategoriaResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Icone = c.Icone ?? string.Empty,
                Cor = c.Cor ?? string.Empty
            });
        }

        public async Task<CategoriaResponse?> ObterPorIdAsync(int id)
        {
            var categoria = await _context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null) return null;

            return new CategoriaResponse
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Icone = categoria.Icone ?? string.Empty,
                Cor = categoria.Cor ?? string.Empty
            };
        }

        public async Task<CategoriaResponse> CriarAsync(CategoriaRequest request)
        {
            var categoria = new Categoria
            {
                Nome = request.Nome,
                Icone = request.Icone,
                Cor = request.Cor,
                UsuarioId = 1,
                DataCriacao = DateTime.Now,
                Ativo = true
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return new CategoriaResponse
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Icone = categoria.Icone ?? string.Empty,
                Cor = categoria.Cor ?? string.Empty
            };
        }

        public async Task<bool> AtualizarAsync(int id, CategoriaRequest request)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return false;

            categoria.Nome = request.Nome;
            categoria.Icone = request.Icone;
            categoria.Cor = request.Cor;
            categoria.DataAtualizacao = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
