using LibraryManager.Core.Usuarios;
using LibraryManager.Core.Usuarios.Repositorios;

namespace LibraryManager.Infrastructure.Repositorios;

public class UsuariosRepository : IUsuariosRepository
{
    public List<Usuario> usuarios { get; set; } = new List<Usuario>();
    public async Task<IEnumerable<Usuario>> BuscarTodosUsuariosAsync()
    {
        return await Task.FromResult(usuarios);
    }

    public async Task<Usuario> BuscarUsuarioPeloIdAsync(int id)
    {
        var usuario = await Task.FromResult(usuarios.FirstOrDefault(x => x.Id == id));
        
        return usuario;
    }

    public async Task<bool> UsuarioJaCadastrado(Usuario usuario)
    {
        return await Task.FromResult(usuarios.Contains(usuario) ? true : false);
    }

    public async Task<bool> Criar(Usuario Usuario)
    {
        usuarios.Add(Usuario);
        
        return await Task.FromResult(true);
    }

    public async Task<bool> Atualizar(Usuario Usuario)
    {
        var usuarioAtualizado = usuarios.FirstOrDefault(x => x.Id == Usuario.Id);
        
        usuarioAtualizado.Id = Usuario.Id;
        usuarioAtualizado.Nome = Usuario.Nome;
        usuarioAtualizado.Senha = Usuario.Senha;
        usuarioAtualizado.Email = Usuario.Email;
        
        return await Task.FromResult(true);
    }

    public async Task<bool> Deletar(Usuario Usuario)
    {
        return await Task.FromResult(usuarios.Remove(Usuario));
    }
}