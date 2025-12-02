using AcoesInvest.Domain.Models;

namespace AcoesInvest.Domain.Interfaces.Services;

public interface IUsuariosService
{
    Task<IEnumerable<Usuarios>> BuscarUsuarios();
    Task<IEnumerable<Usuarios>> BuscarUsuariosNome(string nome);
}
