namespace LibraryManager.Core.Books.Repositorios;

public interface ILivrosRepository
{
    public Task<IEnumerable<Livro>> BuscarTodosLivrosAsync();
    public Task<IEnumerable<Livro>> BuscarLivrosDisponiveisPorTitulo(string titulo);
    public Task<Livro> BuscarLivroPeloIdAsync(int id);
    
    public Task<bool> LivroJaCadastrado(Livro livro);
    public Task<bool> Criar(Livro livro);
    public Task<bool> Atualizar(Livro livro);
    public Task<bool> Deletar(Livro livro);
}