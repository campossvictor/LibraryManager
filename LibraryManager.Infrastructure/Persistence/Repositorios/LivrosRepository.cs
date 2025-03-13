using LibraryManager.Core.Books;
using LibraryManager.Core.Books.Repositorios;

namespace LibraryManager.Infrastructure.Repositorios;

public class LivrosRepository : ILivrosRepository
{
    public List<Livro> Livros { get; set; } = new List<Livro>();
    public async Task<IEnumerable<Livro>> BuscarTodosLivrosAsync()
    {
        return Livros.AsEnumerable();
    }

    public async Task<IEnumerable<Livro>> BuscarLivrosDisponiveisPorTitulo(string titulo)
    {
        var livrosDisponiveis = Livros.Where(livro => livro.Titulo == titulo && livro.Emprestado == false);
        
        return await Task.FromResult(livrosDisponiveis);
    }

    public async Task<Livro> BuscarLivroPeloIdAsync(int id)
    {
        var livro = Livros.FirstOrDefault(livro => livro.Id == id);
        
        return await Task.FromResult(livro);
    }

    public async Task<bool> LivroJaCadastrado(Livro livro)
    {
        var LivroCadastrado = Livros.Any(livro => livro.Id == livro.Id);
        
        return await Task.FromResult(LivroCadastrado);
    }
    public async Task<bool> Criar(Livro livro)
    {
        Livros.Add(livro);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> Atualizar(Livro livro)
    {
        var livroAtualizado = Livros.FirstOrDefault(livro => livro.Id == livro.Id);
        
        livroAtualizado.Id = livro.Id;
        livroAtualizado.Titulo = livro.Titulo;
        livroAtualizado.Emprestado = livro.Emprestado;
        livroAtualizado.Autor = livro.Autor;
        livroAtualizado.Titulo = livro.Titulo;
        livroAtualizado.ISBN = livro.ISBN;
        livroAtualizado.AnoPublicacao = livro.AnoPublicacao;

        return await Task.FromResult(true);
    }

    public async Task<bool> Deletar(Livro livro)
    {
        Livros.Remove(livro);
        
        return await Task.FromResult(true);
    }
}