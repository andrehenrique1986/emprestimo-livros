using AutoMapper;
using EmprestimoDTOLivros.Application.Interfaces;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IMapper _mapper;

        public EmprestimoService(IEmprestimoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmprestimoDTO> Alterar(EmprestimoDTO emprestimoDTO)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoDTO);
            var emprestimoAlterado = await _repository.Alterar(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoAlterado);
        }

        public Task<EmprestimoDTO> Alterar(EmprestimoPutDTO emprestimoPutDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EmprestimoDTO> Excluir(int id)
        {
            var emprestimoExcluido = await _repository.Excluir(id);
            return _mapper.Map<EmprestimoDTO>(emprestimoExcluido);
        }

        public async Task<EmprestimoDTO> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoPostDTO);
            var emprestimoIncluido = await _repository.Incluir(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoIncluido);
        }

       
        public async Task<EmprestimoDTO> SelecionarAsync(int id)
        {
            var emprestimo = await _repository.SelecionarAsync(id);
            return _mapper.Map<EmprestimoDTO>(emprestimo);
        }

        public async Task<IEnumerable<EmprestimoDTO>> SelecionarTodosAsync()
        {
            var emprestimos = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<EmprestimoDTO>>(emprestimos);
        }

        public Task<bool> VerificarDisponibilidadeAsync(int idLivro)
        {
             return _repository.VerificarDisponibilidadeAsync(idLivro);
            
        }
    }        
}
