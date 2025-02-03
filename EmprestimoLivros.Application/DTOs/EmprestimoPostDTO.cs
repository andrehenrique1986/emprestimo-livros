using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoPostDTO
    {
        [Required(ErrorMessage = "O cliente é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do cliente é inválido.")]
        public int LceIdCliente { get; set; }
        [Required(ErrorMessage = "O livro é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do livro é inválido.")]
        public int LceIdLivro { get; set; }
        [Required(ErrorMessage = "A data da entrega é obrigatória.")]
        public DateTime LceDataEntrega { get; set; }
        [JsonIgnore]
        public DateTime LceDataEmprestimo { get; set; }
        [JsonIgnore]
        public bool LceEntregue { get; set; }

    }
}
