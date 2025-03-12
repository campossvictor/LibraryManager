namespace LibraryManager.Core.Usuarios.Repositorios;

public interface IUsuariosRepository
{
    public Task<IEnumerable<Usuario>> BuscarTodosUsuariosAsync();
    
    public Task<Usuario> BuscarUsuarioPeloIdAsync(int id);
    
    public Task<bool> UsuarioJaCadastrado(Usuario usuario);
    public Task<bool> Criar(Usuario Usuario);
    
    public Task<bool> Atualizar(Usuario Usuario);
    
    public Task<bool> Deletar(Usuario Usuario);
}