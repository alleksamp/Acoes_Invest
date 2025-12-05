using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Interfaces.Services;
using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;

namespace AcoesInvest.Domain.Services;

public class UsuariosService : IUsuariosService
{
    private readonly IUsuariosRepository _usuariosRepository;

    public UsuariosService(IUsuariosRepository usuariosRepository)
    {
        _usuariosRepository = usuariosRepository;
    }

    public async Task<IEnumerable<Usuarios>> BuscarUsuarios()
    {
        return await _usuariosRepository.BuscarUsuarios();
    }

    public async Task<IEnumerable<Usuarios>> BuscarUsuariosNome(string nome)
    {
        return await _usuariosRepository.BuscarUsuariosNome(nome);
    }

    public async Task<Usuarios> CadastrarUsuario(Usuarios usuarios)
    {
        var verificaEmail = await _usuariosRepository.Get(x => x.Email == usuarios.Email);
        
        if (verificaEmail != null)
        {
                throw new Exception("Email já cadastrado.");
        }

        await _usuariosRepository.CadastrarUsuarios(usuarios);
        await _usuariosRepository.UnitOfWork.SaveChangesAsync();


        return usuarios;
    }

    public async Task<Usuarios> AtualizarUsuario(AtualizarUsuariosCommand command)
    {
        var usuarios = await _usuariosRepository.Get(x => x.Id == command.Id);
        if (usuarios == null) return null;  

        usuarios.Atualizar(command.Nome, 
            command.Email);

        await _usuariosRepository.AtualizarUsuario(usuarios);
        await _usuariosRepository.UnitOfWork.SaveChangesAsync();
        return usuarios;

    }

    public async Task<bool> DeletarUsuario(int id)
    {
        var usuarios = await _usuariosRepository.Get(x => x.Id == id);
        if (usuarios == null) return false;

        await _usuariosRepository.DeletarUsuario(usuarios);
        await _usuariosRepository.UnitOfWork.SaveChangesAsync();

        return true;
    }

}
