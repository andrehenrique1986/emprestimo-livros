using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.DTOs
{
    public class ClienteDTO
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(14)]
        [MinLength(14, ErrorMessage = "O CPF deve ter, no mínimo, 14 caracteres.")]
        public string CliCpf { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "O Nome deve ter, no máximo, 200 caracteres.")]
        public string CliNome { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "O Endereço deve ter, no máximo, 200 caracteres.")]
        public string CliEndereco { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "A cidade deve ter, no máximo, 200 caracteres.")]
        public string CliCidade { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O Bairro deve ter, no máximo, 100 caracteres.")]
        public string CliBairro { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O Número deve ter, no máximo, 50 caracteres.")]
        public string CliNumero { get; set; }
        [Required]
        [StringLength(14, ErrorMessage = "O Número do celular deve ter, no máximo, 14 caracteres.")]
        public string CliTelefoneCelular { get; set; }
        [Required]
        [Column("cliTelefoneFixo")]
        [StringLength(13, ErrorMessage = "O Número do telefone deve ter, no máximo, 13 caracteres.")]
        public string CliTelefoneFixo { get; set; }
    }
}
