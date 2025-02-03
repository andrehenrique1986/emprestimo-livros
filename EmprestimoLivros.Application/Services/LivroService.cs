﻿using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<LivroDTO> Alterar(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroAlterado = await _repository.Alterar(livro);
            return _mapper.Map<LivroDTO>(livroAlterado);
        }

        public async Task<LivroDTO> Excluir(int id)
        {
            var livroExcluido = await _repository.Excluir(id);
            return _mapper.Map<LivroDTO>(livroExcluido);
        }

        public async Task<LivroDTO> Incluir(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroIncluido = await _repository.Incluir(livro);
            return _mapper.Map<LivroDTO>(livroIncluido);
        }

        public async Task<LivroDTO> SelecionarAsync(int id)
        {
            var livro = await _repository.SelecionarAsync(id);
            return _mapper.Map<LivroDTO>(livro);
        }

        public async Task<IEnumerable<LivroDTO>> SelecionarTodosAsync()
        {
            var livros = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<LivroDTO>>(livros);
        }
    }
}
