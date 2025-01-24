using EmprestimoLivrosNovo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> Incluir(ClienteDTO clienteDTO);
        Task<ClienteDTO> Alterar(ClienteDTO clienteDTO);
        Task<ClienteDTO> Excluir(int id);
        Task<ClienteDTO> SelecionarAsync(int id);
        Task<IEnumerable<ClienteDTO>> SelecionarTodosAsync();
    }
}
