using EmprestimoLivros.Domain.Validation;
using System;

namespace EmprestimoLivros.Domain.Entities
{
    public class Emprestimo
    {
        public int Id { get; private set; }
        public int LceIdCliente { get; private set; }
        public int LceIdLivro { get; private set; }
        public DateTime LceDataEmprestimo { get; private set; }
        public DateTime LceDataEntrega { get; private set; }
        public bool LceEntregue { get; private set; }
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }
        


        public Emprestimo(
            int id, 
            int lceIdCliente,
            int lceIdLivro, 
            DateTime lceDataEmprestimo, 
            DateTime lceDataEntrega, 
            bool lceEntregue 
           
            )
        {
            DomainExceptionValidation.When(id < 0, "O ID do empréstimo deve ser positivo.");
            Id = id;
            ValidateDomain(
                  lceIdCliente,
                  lceIdLivro,
                  lceDataEmprestimo,
                  lceDataEntrega,
                  lceEntregue
                  );
        }

        public void Update(
            int lceIdCliente,
            int lceIdLivro,
            DateTime lceDataEmprestimo,
            DateTime lceDataEntrega,
            bool lceEntregue
            )
        {
            ValidateDomain(
                  lceIdCliente,
                  lceIdLivro,
                  lceDataEmprestimo,
                  lceDataEntrega,
                  lceEntregue
                  );
        }

        public Emprestimo(
            int lceIdCliente, 
            int lceIdLivro, 
            DateTime lceDataEmprestimo, 
            DateTime lceDataEntrega, 
            bool lceEntregue
           
            )
        {
            ValidateDomain(
                lceIdCliente,
                lceIdLivro,
                lceDataEmprestimo,
                lceDataEntrega,
                lceEntregue 
                );
        }

        public void ValidateDomain(
            int lceIdCliente,
            int lceIdLivro,
            DateTime lceDataEmprestimo,
            DateTime lceDataEntrega,
            bool lceEntregue
            )
        {

            DomainExceptionValidation.When(lceIdCliente <= 0 , "O ID do cliente não pode ser maior que 0.");
            DomainExceptionValidation.When(lceIdLivro <= 0, "O ID do livro não pode ser maior que 0.");



            LceIdCliente = lceIdCliente;
            LceIdLivro = lceIdLivro;
            LceDataEmprestimo = lceDataEmprestimo;
            LceDataEntrega = lceDataEntrega;
            LceEntregue = lceEntregue;
        }
    }
}
