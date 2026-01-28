using AcoesInvest.Application.ViewModel;

namespace AcoesInvest.Application.Services.Interfaces;

public interface IAcoesAppService
{
    Task<IEnumerable<AcoesViewModel>> BuscarAcoes(int usuarioId);
    Task<AcoesViewModel> BuscarAcoesId(int Id, int usuarioId);
    Task<IEnumerable<AcoesViewModel>> BuscarAcoesNome(string nome, int usuarioId);
    Task<AcoesViewModel> CadastrarAcoes(NovoAcoesViewModel novoAcoesViewModel, int usuarioId);
    Task<AcoesViewModel> AtualizarAcoes(AtualizarAcoesViewModel atualizarAcoesViewModel, int usuarioId);
    Task<bool> DeletarAcoes(int Id, int usuarioId);
}
