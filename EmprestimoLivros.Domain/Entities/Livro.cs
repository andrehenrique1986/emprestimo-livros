using EmprestimoLivros.Domain.Validation;
using System;
using System.Collections.Generic;

namespace EmprestimoLivros.Domain.Entities
{
    public class Livro
    {
        public int Id { get; private set; }
        public string LivroNome { get; private set; }
        public string LivroAutor { get; private set; }
        public string LivroEditora { get; private set; }
        public DateTime LivroAnoPublicacao { get; private set; }
        public string LivroEdicao { get; private set; }

        public ICollection<Emprestimo>  Emprestimos { get; set; }

        public Livro(
            int id, 
            string livroNome, 
            string livroAutor,
            string livroEditora, 
            DateTime livroAnoPublicacao, 
            string livroEdicao
            )
        {
            DomainExceptionValidation.When(id < 0, "O ID do livro deve ser positivo.");
            Id = id;
            Validatedomain(
                livroNome,
                livroAutor,
                livroEditora,
                livroAnoPublicacao,
                livroEdicao
                );
        }

      
        public Livro(
                string livroNome, 
                string livroAutor,
                string livroEditora, 
                DateTime livroAnoPublicacao, 
                string livroEdicao
            )
        {

            Validatedomain(
                livroNome,
                livroAutor,
                livroEditora,
                livroAnoPublicacao,
                livroEdicao
                );
        }

        public void Update(
                string livroNome,
                string livroAutor,
                string livroEditora,
                DateTime livroAnoPublicacao,
                string livroEdicao
            )
        {
            Validatedomain(
               livroNome,
               livroAutor,
               livroEditora,
               livroAnoPublicacao,
               livroEdicao
               );
        }

        public void Validatedomain(
                string livroNome,
                string livroAutor,
                string livroEditora,
                DateTime livroAnoPublicacao,
                string livroEdicao
            )
        {

            DomainExceptionValidation.When(livroNome.Length > 50 , "O Nome do livro deve ter, no máximo, 50 caracteres.");
            DomainExceptionValidation.When(livroAutor.Length > 200, "O Autor do livro deve ter, no máximo, 200 caracteres.");
            DomainExceptionValidation.When(livroEditora.Length > 50, "A Editora deve ter, no máximo, 50 caracteres.");
            DomainExceptionValidation.When(livroEdicao.Length > 50, "A Edição deve ter, no máximo, 50 caracteres.");


            ValidarAnoPublicacao(livroAnoPublicacao);

            LivroNome = livroNome;
            LivroAutor = livroAutor;
            LivroEditora = livroEditora;
            LivroAnoPublicacao = livroAnoPublicacao;
            LivroEdicao = livroEdicao;
        }

        private void ValidarAnoPublicacao(DateTime livroAnoPublicacao)
        {
            int anoPublicacao = livroAnoPublicacao.Year;
            int anoAtual = DateTime.Now.Year;

            DomainExceptionValidation.When(anoPublicacao < 1500 || anoPublicacao > anoAtual, "O Ano de publicação deve ser entre 1500 e o ano atual.");
        }
    }
}
