using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }


        [HttpPost("/adicionarLivro")]
        public async Task<ActionResult> Incluir(LivroDTO livroDTO)
        {
            var livroDTOIncluido = await _livroService.Incluir(livroDTO);
            if (livroDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir um livro.");
            }

            return Ok("Livro incluído com sucesso!");
        }

        [HttpPut("/alterarLivro")]
        public async Task<ActionResult> Alterar(LivroDTO livroDTO)
        {
            var livroDTOAlterado = await _livroService.Alterar(livroDTO);
            if (livroDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o livro.");
            }
            return Ok("Livro alterado com sucesso!");
        }

        [HttpDelete("/excluirLivro/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
           
            var livroDTOExcluido = await _livroService.Excluir(id);
            if (livroDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir um livro");
            }
            return Ok("Livro excluido com sucesso!");
        }

        [HttpGet("/listarLivroPorId/{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var livroDTO = await _livroService.SelecionarAsync(id);
            if (livroDTO == null)
            {
                return NotFound("Livro não encontrado.");
            }
            return Ok(livroDTO);
        }

        [HttpGet("/listarLivros")]
        public async Task<ActionResult> SelecionarTodos()
        {
            var livroDTO = await _livroService.SelecionarTodosAsync();
            return Ok(livroDTO);
        }
    }
}
