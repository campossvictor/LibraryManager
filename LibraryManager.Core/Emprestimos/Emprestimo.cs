using System.Data;
using LibraryManager.Core.Books;
using LibraryManager.Core.Usuarios;

namespace LibraryManager.Core.Emprestimos;

public class Emprestimo : Entity
{
    public Emprestimo(Usuario usuario, Livro livro)
    {
        DataVencimento = GerarVencimentoEmprestimo();
        Usuario = usuario;
        Livro = livro;
    }
    
    public Emprestimo(){}
    
    public DateTime DataEmprestimo { get; set; } = DateTime.Today;
    public DateTime DataVencimento { get; private set; }
    public Usuario Usuario { get; set; }
    public Livro Livro { get; set; }

    private DateTime GerarVencimentoEmprestimo()
    {
        var dataVencimento = this.DataEmprestimo.AddDays(7);
        
        return dataVencimento;
    }
}