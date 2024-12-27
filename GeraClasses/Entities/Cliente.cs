using System;
using System.Collections.Generic;

#nullable disable

namespace GeraClasses.Entities
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
    }
}
