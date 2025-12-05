using AcoesInvest.Application.ViewModel;
using AcoesInvest.Domain.Models;

namespace AcoesInvest.Application.Services.Interfaces;

public interface IUsuariosAppService
{
    Task<IEnumerable<UsuariosViewModel>> BuscarUsuarios();
    Task<IEnumerable<UsuariosViewModel>> BuscarUsuariosNome(string nome);
    Task<UsuariosViewModel> CadastrarUsuario(NovoUsuariosViewModel novoUsuariosViewModel);
    Task<UsuariosViewModel> AtualizarUsuario(AtualizarUsuariosViewModel atualizarUsuariosViewModel);
    Task<bool>  DeletarUsuario(int id);

}
