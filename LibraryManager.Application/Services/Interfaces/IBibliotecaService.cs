using LibraryManager.Application.DTO;
using LibraryManager.Core.Emprestimos;

namespace LibraryManager.Application.Interfaces.Services;

public interface IBibliotecaService
{
   public Task<Emprestimo> EmprestarLivro(string titulo, int usuarioId);
}