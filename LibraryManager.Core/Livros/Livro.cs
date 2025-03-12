using System.ComponentModel.DataAnnotations;
using LibraryManager.Core.Usuarios;

namespace LibraryManager.Core.Books;

public class Livro : Entity
{
    public Livro(string titulo, string autor, string isbn, int anoPublicacao, bool emprestado)
    {
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        AnoPublicacao = anoPublicacao;
        Emprestado = emprestado;
    }
    
    public Livro(){}
    
    [Required]
    public string Titulo { get; set; }
    
    [Required]
    public string Autor { get; set; }
    
    [Required]
    public string ISBN { get; set; }
    
    public int AnoPublicacao { get; set; }
    
    public bool Emprestado { get; set; }

    public Usuario Usuario { get; set; }
    
    public void EmprestarLivro()
    {
        if (Emprestado)
            throw new Exception("Livros não está disponível para empréstimo");
        
        Emprestado = true;
    }
}