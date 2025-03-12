using LibraryManager.Core.Books;

namespace LibraryManager.Core.Emprestimos.Repositorio;

public interface IEmprestimoRepository
{
    public Task<IEnumerable<Emprestimo>> BuscarTodosEmprestimosAsync();
    
    public Task<IEnumerable<Livro>> BuscaEmprestimoPorTituloEmAberto(string titulo);
    public Task<bool> Criar(Emprestimo Emprestimo);
    
    public Task<bool> Atualizar(Emprestimo Emprestimo);
    
    public Task<bool> Deletar(Emprestimo Emprestimo);
}