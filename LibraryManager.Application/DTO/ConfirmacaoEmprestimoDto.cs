using LibraryManager.Core.Books;
using LibraryManager.Core.Emprestimos;
using LibraryManager.Core.Usuarios;

namespace LibraryManager.Application.DTO;

public class ConfirmacaoEmprestimoDto
{
    public int EmprestimoId { get; set; }
    
    public Livro Livro { get; set; }
    
    public Usuario Usuario { get; set; }
}