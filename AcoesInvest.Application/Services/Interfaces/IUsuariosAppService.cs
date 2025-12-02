using AcoesInvest.Application.ViewModel;

namespace AcoesInvest.Application.Services.Interfaces;

public interface IUsuariosAppService
{
    Task<IEnumerable<UsuariosViewModel>> BuscarUsuarios();
    Task<IEnumerable<UsuariosViewModel>> BuscarUsuariosNome(string nome);

}
