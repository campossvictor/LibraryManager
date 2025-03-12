using LibraryManager.Core.Usuarios;

namespace LibraryManager.Application.Interfaces.Services;

public interface IUsuarioService
{
    public Task<IEnumerable<Usuario>> BuscarUsuarios();
    
    public Task<Usuario> BuscarUsuarioPorId(int id);
        
    public Task<bool> RegistrarUsuario(Usuario usuario);
    
    public Task<bool> EditarUsuario(int usuarioId, Usuario usuario);
    
    public Task<bool> DeletarUsuario(int usuarioId);
}