using System;
using System.Collections.Generic;

#nullable disable

namespace GeraClasses.Entities
{
    public partial class LivroClienteEmprestimo
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
