using EmprestimoDTOLivros.Application.Interfaces;
using EmprestimoLivros.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoService _emprestimoService;
        

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }


        [HttpPost("/adicionarEmprestimo")]
        public async Task<ActionResult> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {

            var disponivel = await _emprestimoService.VerificarDisponibilidadeAsync(emprestimoPostDTO.LceIdLivro);

            if (!disponivel)
            {
                return BadRequest("O livro não está disponível para empréstimo");
            }

            emprestimoPostDTO.LceDataEmprestimo = DateTime.Now;
            emprestimoPostDTO.LceEntregue = false;
            var emprestimoDTOIncluido = await _emprestimoService.Incluir(emprestimoPostDTO);
            if (emprestimoDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir um cliente.");
            }

            return Ok("Emprestimo incluído com sucesso!");
        }

        [HttpPut("/alterarEmprestimo")]
        public async Task<ActionResult> Alterar(EmprestimoPutDTO emprestimoPutDTO)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(emprestimoPutDTO.Id);

            if (emprestimoDTO == null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            emprestimoDTO.LceDataEntrega = emprestimoPutDTO.LceDataEntrega;
            emprestimoDTO.LceEntregue = emprestimoPutDTO.LceEntregue;

            var emprestimoDTOAlterado = _emprestimoService.Alterar(emprestimoDTO);

            if (emprestimoDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente.");
            }
            return Ok("Emprestimo alterado com sucesso!");
        }

        [HttpDelete("/excluirEmprestimo/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            
            var emprestimoDTOExcluido = await _emprestimoService.Excluir(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir um empréstimo");
            }
            return Ok("Emprestimo excluido com sucesso!");
        }

        [HttpGet("/listarEmprestimoPorId/{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(id);
            if (emprestimoDTO == null)
            {
                return NotFound("Emprestimo não encontrado.");
            }
            return Ok(emprestimoDTO);
        }

        [HttpGet("/listarEmprestimos")]
        public async Task<ActionResult> SelecionarTodos()
        {
            var emprestimoDTO = await _emprestimoService.SelecionarTodosAsync();
            return Ok(emprestimoDTO);
        }


    }
}

