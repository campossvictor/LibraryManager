using LibraryManager.Core.Books;
using LibraryManager.Core.Usuarios;

namespace LibraryManager.Application.Interfaces.Services;

public interface ILivroService
{
    public Task<IEnumerable<Livro>> BuscarLivros();
    public Task<Livro> BuscarLivroPorId(int id);
    public Task<bool> RegistrarLivro(Livro Livro);
    public Task<bool> EditarLivro(int livroid, Livro Livro);
    public Task<bool> DeletarLivro(int livroId);
}