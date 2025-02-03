using System;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoPutDTO
    {
        [Required(ErrorMessage = "O identificador do empréstimo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do empréstimo é inválido.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "A data de entrega é obrigatória.")]
        public DateTime LceDataEntrega { get; set; }
        [Required(ErrorMessage = "O estado da entrega é obrigatório.")]
        public bool LceEntregue { get; set; }
    }
}
