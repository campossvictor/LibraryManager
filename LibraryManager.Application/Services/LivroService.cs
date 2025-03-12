using LibraryManager.Application.Interfaces.Services;
using LibraryManager.Core.Books;
using LibraryManager.Core.Books.Repositorios;

namespace LibraryManager.Application.Services;

public class LivroService : ILivroService
{
    private readonly ILivrosRepository _livrosRepository;

    public LivroService(ILivrosRepository livrosRepository)
    {
        _livrosRepository = livrosRepository;
    }
    
    public async Task<IEnumerable<Livro>> BuscarLivros()
    {
        var livros = await _livrosRepository.BuscarTodosLivrosAsync();
        
        return livros;
    }

    public async Task<Livro> BuscarLivroPorId(int id)
    {
        var livro = await _livrosRepository.BuscarLivroPeloIdAsync(id);
        
        return livro;
    }

    public async Task<bool> RegistrarLivro(Livro livro)
    {
        if(livro == null)
            throw new ArgumentNullException(nameof(livro));
        
        var LivroCadastrado = await _livrosRepository.LivroJaCadastrado(livro);

        if (LivroCadastrado)
            throw new InvalidOperationException("Livro já está cadastrado");
        
        var livroCadastrado = await _livrosRepository.Criar(livro);

        return livroCadastrado;
    }

    public async Task<bool> EditarLivro(int livroId, Livro Livro)
    {
        if(livroId != Livro.Id)
            throw new InvalidOperationException("Livros indicados para atualização são diferentes");
        
        var LivroCadastrado = await _livrosRepository.LivroJaCadastrado(Livro);
        
        if (!LivroCadastrado)
            throw new InvalidOperationException("Livro com o Id indicado não existe");
        
        var livroEditado = await _livrosRepository.Atualizar(Livro);
        
        return livroEditado;
    }

    public async Task<bool> DeletarLivro(int livroId)
    {
        
        var usuarioDeletado = await _livrosRepository.BuscarLivroPeloIdAsync(livroId);

        if (usuarioDeletado == null)
            throw new InvalidOperationException("Usuário não existe!");
        
        var EstaDeletado = await _livrosRepository.Deletar(usuarioDeletado);

        return EstaDeletado;
    }
}