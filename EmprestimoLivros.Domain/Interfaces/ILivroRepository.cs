using EmprestimoLivros.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<Livro> Incluir(Livro livro);
        Task<Livro> Alterar(Livro livro);
        Task<Livro> Excluir(int id);
        Task<Livro> SelecionarAsync(int id);
        Task<IEnumerable<Livro>> SelecionarTodosAsync();
    }
}
