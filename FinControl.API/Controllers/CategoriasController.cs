using FinControl.API.DTOs.Categoria;
using FinControl.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponse>>> Get()
        {
            var categorias = await _categoriaService.ListarTodasAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponse>> GetById(int id)
        {
            var categoria = await _categoriaService.ObterPorIdAsync(id);
            
            if (categoria == null)
                return NotFound(new { mensagem = "Categoria nao encontrada" });

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaResponse>> Post([FromBody] CategoriaRequest request)
        {
            var novaCategoria = await _categoriaService.CriarAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = novaCategoria.Id }, novaCategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaRequest request)
        {
            var atualizado = await _categoriaService.AtualizarAsync(id, request);

            if (!atualizado)
                return NotFound(new { mensagem = "Categoria nao encontrada para atualizacao" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _categoriaService.DeletarAsync(id);

            if (!deletado)
                return NotFound(new { mensagem = "Categoria nao encontrada para exclusao" });

            return NoContent();
        }
    }
}
