﻿using EmprestimoLivros.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoDTOLivros.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<EmprestimoDTO> Incluir(EmprestimoPostDTO emprestimoPostDTO);
        Task<EmprestimoDTO> Alterar(EmprestimoDTO emprestimoDTO);
        Task<EmprestimoDTO> Excluir(int id);
        Task<EmprestimoDTO> SelecionarAsync(int id);
        Task<IEnumerable<EmprestimoDTO>> SelecionarTodosAsync();
        Task<bool> VerificarDisponibilidadeAsync(int idLivro);
        
    }
}
