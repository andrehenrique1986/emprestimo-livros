using EmprestimoLivros.API.Context;
using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;  // Usar Microsoft.EntityFrameworkCore em vez de System.Data.Entity
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprestimoLivros.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ControleEmprestimoContext _context;

        public ClienteRepository(ControleEmprestimoContext context)
        {
            _context = context;
        }

        public void Alterar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);  
        }

        public void Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);  
        }

        public void Incluir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);  
        }

        
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0; 
        }

        // Método para selecionar um cliente pelo Id (chave primária)
        public async Task<Cliente> SelecionarByPk(int id)
        {
            return await _context.Clientes
                                 .Where(x => x.Id == id)
                                 .FirstOrDefaultAsync();  
        }

        // Método assíncrono para selecionar todos os clientes
        public async Task<IEnumerable<Cliente>> SelecionarTodos()
        {
            return await _context.Clientes.ToListAsync();  
        }
    }
}

