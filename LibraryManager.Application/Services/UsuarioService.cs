using LibraryManager.Application.Interfaces.Services;
using LibraryManager.Core.Usuarios;
using LibraryManager.Core.Usuarios.Repositorios;

namespace LibraryManager.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuariosRepository _usuariosRepository;

    public UsuarioService(IUsuariosRepository usuariosRepository)
    {
        _usuariosRepository = usuariosRepository;
    }
    
    public async Task<IEnumerable<Usuario>> BuscarUsuarios()
    {
        return await _usuariosRepository.BuscarTodosUsuariosAsync();
    }
    public async Task<Usuario> BuscarUsuarioPorId(int id)
    {
        return await _usuariosRepository.BuscarUsuarioPeloIdAsync(id);
    }

    public async Task<bool> RegistrarUsuario(Usuario usuario)
    {
        if(usuario == null)
            throw new ArgumentNullException(nameof(usuario));
        
        var usuarioCadastrado = await _usuariosRepository.Criar(usuario);

        return usuarioCadastrado;
    }

    public async Task<bool> EditarUsuario(int usuarioId, Usuario usuario)
    {
        if(usuarioId != usuario.Id)
            throw new InvalidOperationException("Usuário a ser editado são diferentes");
        
        var usuarioCadastrado = await _usuariosRepository.UsuarioJaCadastrado(usuario);
        
        if (!usuarioCadastrado)
            throw new InvalidOperationException("Livro com o Id indicado não existe");
        
        var usuarioEditado = await _usuariosRepository.Atualizar(usuario);
        
        return usuarioEditado;
    }

    public async Task<bool> DeletarUsuario(int usuarioId)
    {
        var usuarioDetalhes = await _usuariosRepository.BuscarUsuarioPeloIdAsync(usuarioId);
        
        if (usuarioDetalhes == null)
            throw new InvalidOperationException("Usuário não existe!");
        
        var EstaDeletado = await _usuariosRepository.Deletar(usuarioDetalhes);
        
        return EstaDeletado;
    }
}