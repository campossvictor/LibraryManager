using LibraryManager.Application.Interfaces.Services;
using LibraryManager.Core.Books.Repositorios;
using LibraryManager.Core.Emprestimos;
using LibraryManager.Core.Emprestimos.Repositorio;

namespace LibraryManager.Application.Services;

public class BibliotecaService : IBibliotecaService
{
    private readonly ILivrosRepository _livroRepository;
    private readonly IUsuarioService _usuarioService;
    private readonly IEmprestimoRepository _emprestimoRepository;
    
    public async Task<Emprestimo> EmprestarLivro(string titulo, int usuarioId)
    {
        var LivrosDisponiveis = await _livroRepository.BuscarLivrosDisponiveisPorTitulo(titulo);
        
        if(!LivrosDisponiveis.Any())
            throw new InvalidOperationException("Nenhum livro disponível com esse titulo."); 
        
        var livroEmprestimo = LivrosDisponiveis.First();
        livroEmprestimo.EmprestarLivro();
        
        var usuarioEmprestimo = await _usuarioService.BuscarUsuarioPorId(usuarioId);
        usuarioEmprestimo.AdicionarLivro(livroEmprestimo);
        
        var NovoEmprestimo = new Emprestimo(usuarioEmprestimo, livroEmprestimo);
        
        _livroRepository.Atualizar(livroEmprestimo);
        _emprestimoRepository.Criar(NovoEmprestimo);
        
        return NovoEmprestimo;
    }
}