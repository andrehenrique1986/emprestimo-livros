using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivrosNovo.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost("/adicionarCliente")]
        public async Task<ActionResult> Incluir(ClienteDTO clienteDTO)
        {
            var clienteDTOIncluido = await _clienteService.Incluir(clienteDTO);
            if (clienteDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir um cliente.");
            }

            return Ok("Cliente incluído com sucesso!");
        }

        [HttpPut("/alterarCliente")]
        public async Task<ActionResult> Alterar(ClienteDTO clienteDTO)
        {
            var clienteDTOAlterado = await _clienteService.Alterar(clienteDTO);
            if (clienteDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente.");
            }
            return Ok("Cliente alterado com sucesso!");
        }

        [HttpDelete("/excluirCliente/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var clienteDTOExcluido = await _clienteService.Excluir(id);
            if (clienteDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir um cliente");
            }
            return Ok("Cliente excluido com sucesso!");
        }

        [HttpGet("/listarClientePorId/{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var clienteDTO = await _clienteService.SelecionarAsync(id);
            if(clienteDTO == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(clienteDTO);
        }

        [HttpGet("/listarClientes")]
        public async Task<ActionResult> SelecionarTodos()
        {
            var clienteDTO = await _clienteService.SelecionarTodosAsync();
            return Ok(clienteDTO);
        }


    }
}
