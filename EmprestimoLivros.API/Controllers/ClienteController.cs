using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet("selecionarTodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteRepository.SelecionarTodos();
                var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                return Ok(clientesDTO);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao listar os clientes: {ex.Message}");
            }
        }


        [HttpPost("cadastrarCliente")]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                _clienteRepository.Incluir(cliente);

                if (await _clienteRepository.SaveAllAsync())
                {
                    return Ok("Cliente cadastrado com sucesso !");
                }

                return BadRequest("Ocorreu um erro ao salvar o cliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o cliente: {ex.Message}");
            }
        }

        [HttpPut("alterarCliente")]
        public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO.Id == 0)
                {
                    return BadRequest("Não é possível alterar o cliente. É preciso informar o ID");
                }

                var clienteExiste = await _clienteRepository.SelecionarByPk(clienteDTO.Id);
                if (clienteExiste == null)
                {
                    return NotFound("Cliente não encontrado.");
                }

                
                _mapper.Map(clienteDTO, clienteExiste);

                
                _clienteRepository.Alterar(clienteExiste);

                
                if (await _clienteRepository.SaveAllAsync())
                {
                    return Ok("Cliente alterado com sucesso !");
                }

                return BadRequest("Ocorreu um erro ao alterar o cliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao alterar um cliente: {ex.Message}");
            }
        }


        [HttpDelete("excluirCliente/{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            try
            {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _clienteRepository.Excluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente excluído com sucesso !");
            }
            return BadRequest("Ocorreu um erro ao excluir o cliente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir o cliente {ex.Message}");
            }
        }

        [HttpGet("selecionarClientePorId/{id}")]
        public async Task<ActionResult> SelecionarCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.SelecionarByPk(id);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado.");
                }



                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

                return Ok(clienteDTO);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao buscar o cliente: {ex.Message}");
            }
        }

    }
}

