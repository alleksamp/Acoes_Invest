using AcoesInvest.Domain.Models;

namespace AcoesInvest.Domain.Interfaces.Repositories;

public interface IUsuariosRepository : IBaseRepository<Usuarios>
{
    Task<IEnumerable<Usuarios>> BuscarUsuarios();
    Task<IEnumerable<Usuarios>> BuscarUsuariosNome(string nome);
    Task CadastrarUsuarios(Usuarios usuarios);
    Task AtualizarUsuario(Usuarios usuarios);
    Task DeletarUsuario(Usuarios usuarios);
}
