using System.Data;
using LibraryManager.Core.Books;

namespace LibraryManager.Core.Usuarios;

public class Usuario : Entity
{
    public Usuario(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }
    public Usuario(){}
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    public string Senha { get; set; }
    
    public List<Livro> Livros { get; set; } = new List<Livro>();

    public void AdicionarLivro(Livro livro)
    {
        if (Livros.Contains(livro))
            throw new Exception("Usuário já possui o livro em sua lista de livros emprestados");
        
        Livros.Add(livro);
    }
}