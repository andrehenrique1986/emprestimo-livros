using System;

namespace EmprestimoLivros.API.Models
{

    public class LivroClienteEmprestimo
    {
       
        public int Id { get; set; }
        
        public int IdLivro { get; set; }
       
        public int IdCliente { get; set; }

        
        public DateTime DataEmprestimo { get; set; }
      
        public DateTime DataDevolucao { get; set; }


        public virtual Livro Livro { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
