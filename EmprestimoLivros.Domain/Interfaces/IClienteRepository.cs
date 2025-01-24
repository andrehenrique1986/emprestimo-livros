﻿using EmprestimoLivros.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Incluir(Cliente cliente);
        Task<Cliente> Alterar(Cliente cliente);
        Task<Cliente> Excluir(int id);
        Task<Cliente> SelecionarAsync(int id);
        Task<IEnumerable<Cliente>> SelecionarTodosAsync();
    }
}
