using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;

namespace AcoesInvest.Domain.Interfaces.Services;

public interface IUsuariosService
{
    Task<IEnumerable<Usuarios>> BuscarUsuarios();
    Task<IEnumerable<Usuarios>> BuscarUsuariosNome(string nome);
    Task<Usuarios> CadastrarUsuario(Usuarios usuarios);
    Task<Usuarios> AtualizarUsuario(AtualizarUsuariosCommand command);
    Task<bool> DeletarUsuario(int id);
}
