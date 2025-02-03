using EmprestimoLivrosNovo.Application.DTOs;
using System;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoDTO
    {
        public int Id { get; set; }
        public int LceIdCliente { get; set; }
        public int LceIdLivro { get; set; }
        public DateTime LceDataEmprestimo { get; set; }
        public DateTime LceDataEntrega { get; set; }
        public bool LceEntregue { get; set; }
        public ClienteDTO ClienteDTO { get; set; }
        public LivroDTO LivroDTO { get; set; }
    }
}
