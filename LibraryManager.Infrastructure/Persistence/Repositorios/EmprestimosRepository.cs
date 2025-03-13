using LibraryManager.Core.Books;
using LibraryManager.Core.Emprestimos;
using LibraryManager.Core.Emprestimos.Repositorio;

namespace LibraryManager.Infrastructure.Repositorios;

public class EmprestimosRepository : IEmprestimoRepository
{
    public List<Emprestimo> emprestimos = new List<Emprestimo>();
    
    public async Task<IEnumerable<Emprestimo>> BuscarTodosEmprestimosAsync()
    {
        return await Task.FromResult(emprestimos);
    }
    public async Task<bool> Criar(Emprestimo Emprestimo)
    {
        emprestimos.Add(Emprestimo);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> Atualizar(Emprestimo Emprestimo)
    {
        var emprestimoAtualizado = emprestimos.FirstOrDefault(e => e.Id == Emprestimo.Id);
        
        emprestimoAtualizado.DataEmprestimo = Emprestimo.DataEmprestimo;
        emprestimoAtualizado.Livro = Emprestimo.Livro;
        emprestimoAtualizado.Usuario = Emprestimo.Usuario;
        emprestimoAtualizado.DataCriacao = Emprestimo.DataCriacao;
        emprestimoAtualizado.DataVencimento = Emprestimo.DataVencimento;
        emprestimoAtualizado.Id = Emprestimo.Id;
        
        return await Task.FromResult(true);
        
    }

    public async Task<bool> Deletar(Emprestimo Emprestimo)
    {
        emprestimos.Remove(Emprestimo);
        
        return await Task.FromResult(true);
    }
}